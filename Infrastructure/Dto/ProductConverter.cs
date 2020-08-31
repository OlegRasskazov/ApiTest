using Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Dto
{
    public class ProductConverter : JsonConverter<Product>
    {
        

        public override void WriteJson(JsonWriter writer, [AllowNull] Product value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Name);
        }

        public override Product ReadJson(JsonReader reader, Type objectType, [AllowNull] Product existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Product product = new Product();
            product.Name = (string)reader.Value;

            return product;
        }
    }
}
