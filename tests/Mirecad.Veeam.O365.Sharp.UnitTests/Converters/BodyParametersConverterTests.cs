using System.IO;
using System.Text;
using FluentAssertions;
using Mirecad.Veeam.O365.Sharp.Converters;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Mirecad.Veeam.O365.Sharp.UnitTests.Converters
{
    public class BodyParametersConverterTests
    {
        private readonly BodyParametersConverter _sut = new BodyParametersConverter();
        private readonly JsonSerializer _serializer;

        public BodyParametersConverterTests()
        {
            var jsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            jsonSettings.Converters.Add(new StringEnumConverter());
            _serializer = JsonSerializer.Create(jsonSettings);
        }

        private class ClassA
        {
            public string Name { get; set; }
            public string TestProperty { get; set; }
        }

        [Fact]
        public void CanIgnoreNullOnNestedProperties()
        {
            var sampleClass = new ClassA{Name = "name"};
            var parameters = new BodyParameters()
                .AddOptionalParameter("param", sampleClass);

            var sb = ConvertToJson(parameters);

            var expectedJson = @"{""param"":{""Name"":""name""}}";
            JToken expected = JToken.Parse(expectedJson);
            JToken actual = JToken.Parse(sb.ToString());

            JToken.DeepEquals(actual, expected).Should().BeTrue();
        }

        [Fact]
        public void CanWriteNullProperty()
        {
            var parameters = new BodyParameters()
                .AddNullParameter("param");

            var sb = ConvertToJson(parameters);

            var expectedJson = @"{""param"":null}";
            JToken expected = JToken.Parse(expectedJson);
            JToken actual = JToken.Parse(sb.ToString());

            JToken.DeepEquals(actual, expected).Should().BeTrue();
        }

        private StringBuilder ConvertToJson(BodyParameters parameters)
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using JsonWriter writer = new JsonTextWriter(sw);
            _sut.WriteJson(writer, parameters, _serializer);
            return sb;
        }
    }
}