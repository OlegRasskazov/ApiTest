using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Formatters
{
    public class ProviderInputFormatter  //TextInputFormatter
    {
        //public ProviderInputFormatter()
        //{
        //    SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
        //    SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/xml"));

        //    SupportedEncodings.Add(Encoding.UTF8);
        //    SupportedEncodings.Add(Encoding.Unicode);
        //}
        //public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        //{
        //    var httpContext = context.HttpContext;
        //    var serviceProvider = httpContext.RequestServices;

        //    using var reader = new StreamReader(httpContext.Request.Body, encoding);

        //} 
    }
}
