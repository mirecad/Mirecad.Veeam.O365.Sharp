using System;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mirecad.Veeam.O365.Sharp.Converters
{
    public class BodyParametersConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            bool notCorrectTypeOfValue = false == value is BodyParameters;
            if (notCorrectTypeOfValue)
            {
                throw new ArgumentException($"This Json converter can convert only objects of type {nameof(BodyParameters)}");
            }

            var parameters = (BodyParameters) value;
            writer.WriteStartObject();
            foreach (var parameter in parameters.GetParameters())
            {
                writer.WritePropertyName(parameter.Key);
                if (parameter.Value == null)
                {
                    writer.WriteNull();
                }
                else
                {
                    JToken.FromObject(parameter.Value, serializer).WriteTo(writer);
                }
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BodyParameters);
        }
    }
}