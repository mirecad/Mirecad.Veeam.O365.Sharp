using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using Mirecad.Veeam.O365.Sharp.Converters;
using Mirecad.Veeam.O365.Sharp.Objects.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Mirecad.Veeam.O365.Sharp.UnitTests.Converters
{
    public class JobItemCollectionConverterTests
    {
        private readonly JobItemCollectionConverter _sut = new JobItemCollectionConverter();

        [Fact]
        public void CanDistinguishItemsBasedOnType()
        {
            var json = @"[{
                ""type"": ""PartialOrganization"",
                ""mailbox"": true,
                ""oneDrive"": true,
                ""archiveMailbox"": true,
                ""site"": true,
                ""id"": ""c37da450-6c4b-48c4-87e2-cc557ef5d8975db60525-e59f-49b9-b49b-407fc9bf2642"",
                ""_links"": {}
            }]";
            JsonReader reader = new JTokenReader(JToken.Parse(json));

            var obj = _sut.ReadJson(reader, typeof(JobItemCollectionDto), null, JsonSerializer.CreateDefault());
            var actual = obj as JobItemCollectionDto;

            var expected = new JobItemCollectionDto();
            expected.PartialOrganizations.Add(new PartialOrganizationJobItemDto()
            {
                ArchiveMailbox = true,
                Id = "c37da450-6c4b-48c4-87e2-cc557ef5d8975db60525-e59f-49b9-b49b-407fc9bf2642",
                Mailbox = true,
                OneDrive = true,
                Site = true,
                Type = "PartialOrganization"
            });

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CanWriteDifferentObjectsIntoSingleArray()
        {
            var jobItemsCol = new JobItemCollectionDto();
            jobItemsCol.PartialOrganizations.Add(new PartialOrganizationJobItemDto()
            {
                ArchiveMailbox = true,
                Id = "c37da450-6c4b-48c4-87e2-cc557ef5d8975db60525-e59f-49b9-b49b-407fc9bf2642",
                Mailbox = true,
                OneDrive = true,
                Site = true,
                Type = "PartialOrganization"
            });
            jobItemsCol.Sites.Add(new SiteJobItemDto()
            {
                Id = "94f50108-75b4-4a5e-89ae-5651ee1e3975fdc607c4-6ac6-47d9-a1f3-cbdbc9766174",
                Links = null,
                Site = null,
                Type = "Site"
            });

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            using JsonWriter writer = new JsonTextWriter(sw);
            _sut.WriteJson(writer, jobItemsCol, JsonSerializer.CreateDefault());

            var expectedJson = @"[{
                ""Type"": ""PartialOrganization"",
                ""Mailbox"": true,
                ""OneDrive"": true,
                ""ArchiveMailbox"": true,
                ""Site"": true,
                ""Id"": ""c37da450-6c4b-48c4-87e2-cc557ef5d8975db60525-e59f-49b9-b49b-407fc9bf2642""
            },
            { 
                ""Type"": ""Site"",
                ""Id"": ""94f50108-75b4-4a5e-89ae-5651ee1e3975fdc607c4-6ac6-47d9-a1f3-cbdbc9766174"",           
                ""_links"": null,
                ""Site"": null
            }]";
            JToken expected = JToken.Parse(expectedJson);
            JToken actual = JToken.Parse(sb.ToString());

            JToken.DeepEquals(actual, expected).Should().BeTrue();
        }
    }
}