using Infrastructure.Models;
using Infrastructure.Models.BindingModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApplicationCore.Formatters
{
    public class ProductInputJsonFormatter : TextInputFormatter
    {
        public ProductInputJsonFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var httpContext = context.HttpContext;

            using var reader = new StreamReader(httpContext.Request.Body, encoding);

            try
            {
                var json = await reader.ReadToEndAsync();
                var providerMessageModel = JsonConvert.DeserializeObject<ProviderMessageModel>(json);
                // можно вынести в настройки
                providerMessageModel.Name = "ProviderA";
                return await InputFormatterResult.SuccessAsync(providerMessageModel.GetProviderEntity());
            }
            catch
            {
                return await InputFormatterResult.FailureAsync();
            }

        }

    }
}
