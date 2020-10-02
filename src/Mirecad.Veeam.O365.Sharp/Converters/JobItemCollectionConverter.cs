using System;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mirecad.Veeam.O365.Sharp.Converters
{
    public class JobItemCollectionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            bool notCorrectTypeOfValue = false == value is JobItemCollectionDto;
            if (notCorrectTypeOfValue)
            {
                throw new ArgumentException($"This Json converter can convert only objects of type {nameof(JobItemCollectionDto)}");
            }

            var jobItemsCol = (JobItemCollectionDto)value;
            writer.WriteStartArray();
            foreach (var organization in jobItemsCol.PartialOrganizations)
            {
                JToken.FromObject(organization).WriteTo(writer);
            }
            foreach (var user in jobItemsCol.Users)
            {
                JToken.FromObject(user).WriteTo(writer);
            }
            foreach (var site in jobItemsCol.Sites)
            {
                JToken.FromObject(site).WriteTo(writer);
            }
            foreach (var group in jobItemsCol.Groups)
            {
                JToken.FromObject(group).WriteTo(writer);
            }
            writer.WriteEnd();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (objectType != typeof(JobItemCollectionDto))
            {
                throw new ArgumentException($"This Json converter can convert only objects of type {nameof(JobItemCollectionDto)}");
            }

            JArray jsonArray = JArray.Load(reader);

            var result = new JobItemCollectionDto();

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
            return objectType == typeof(PartialOrganizationJobItemDto);
        }
    }
}