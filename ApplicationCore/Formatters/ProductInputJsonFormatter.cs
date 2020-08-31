using Infrastructure.Models.BindingModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

                switch (httpContext.Request.Method)
                {
                    case Http.Post:
                    var providerMessageModel = JsonConvert.DeserializeObject<ProviderMessageModel>(json);
                    // можно вынести в настройки
                    providerMessageModel.Name = "ProviderA";
                    return await InputFormatterResult.SuccessAsync(providerMessageModel.GetProviderEntity());
                    default:
                        return await InputFormatterResult.FailureAsync();
                }
            }
            catch
            {
                return await InputFormatterResult.FailureAsync();
            }

        }

    }
}
