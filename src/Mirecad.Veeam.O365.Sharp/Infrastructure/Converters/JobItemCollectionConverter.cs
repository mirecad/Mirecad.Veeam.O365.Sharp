using System;
using Mirecad.Veeam.O365.Sharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Converters
{
    public class JobItemCollectionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JArray jsonArray = JArray.Load(reader);

            var result = new JobItemCollectionResultDto();

            foreach (var jObject in jsonArray.Children())
            {
                string type = jObject["type"].ToObject<string>();
                switch (type)
                {
                    case "Site":
                        var site = new SiteJobItemDto();
                        JsonSerializer.CreateDefault().Populate(jObject.CreateReader(), site);
                        result.Sites.Add(site);
                        break;
                    case "Group":
                        var group = new GroupJobItemDto();
                        JsonSerializer.CreateDefault().Populate(jObject.CreateReader(), group);
                        result.Groups.Add(group);
                        break;
                    case "User":
                        var user = new UserJobItemDto();
                        JsonSerializer.CreateDefault().Populate(jObject.CreateReader(), user);
                        result.Users.Add(user);
                        break;
                    case "PartialOrganization":
                        var organization = new PartialOrganizationJobItemDto();
                        JsonSerializer.CreateDefault().Populate(jObject.CreateReader(), organization);
                        result.PartialOrganizations.Add(organization);
                        break;
                    default:
                        throw new ArgumentException($"Uknown JobItem type \"{type}\".");
                }

            }

            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}