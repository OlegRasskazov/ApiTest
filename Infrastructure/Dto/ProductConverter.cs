using Infrastructure.Models;
using Newtonsoft.Json;
using System;

namespace Infrastructure.Dto
{
    public class ProductConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Product product = (Product)value;

            writer.WriteValue(product.Name);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Product product = new Product();
            product.Name = (string)reader.Value;

            return product;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Product);
        }
    }
}
