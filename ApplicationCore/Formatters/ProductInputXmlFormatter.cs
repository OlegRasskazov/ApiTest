using Infrastructure.Models;
using Infrastructure.Models.BindingModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ApplicationCore.Formatters
{
    public class ProductInputXmlFormatter : TextInputFormatter
    {
        public ProductInputXmlFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/xml"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var httpContext = context.HttpContext;
            var result = new Provider() { Name = "ProviderB", Companies = new List<Company>() };

            using var reader = new StreamReader(httpContext.Request.Body, encoding);

            try
            {
                var xml = await reader.ReadToEndAsync();
                var xDocument = XDocument.Parse(xml.ToLower());

                var providerMessageModel = new ProviderMessageModel()
                {
                    LoadTime = DateTime.Now,
                    Name = "ProviderB",
                    Companies = xDocument.Element("loaditems")
                    .Elements("item")
                    .Select(i => new Tuple<string, ProductAModel>(
                        i.Attribute("company").Value,
                        new ProductAModel()
                        {
                            Value = i.Element("name").Value,
                            Number = int.Parse(i.Element("amount").Value)
                        })
                    )
                    .GroupBy(t => t.Item1).ToDictionary(x => x.Key, x => x.Select(s => s.Item2).ToArray())
                };

                return await InputFormatterResult.SuccessAsync(providerMessageModel.GetProviderEntity());
            }
            catch
            {
                return await InputFormatterResult.FailureAsync();
            }
        }
    }
}
