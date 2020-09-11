using FluentAssertions;
using Mirecad.Veeam.O365.Sharp.Infrastructure.Http;
using Xunit;

namespace Mirecad.Veeam.O365.Sharp.UnitTests.Infrastructure.Http
{
    public class QueryParametersTests
    {
        [Fact]
        public void CanAcceptIntegerParameter()
        {
            var key = "key";
            var value = 3;

            var parameters = new QueryParameters()
                .AddOptionalParameter(key, value);

            parameters.GetParameters()
                .Should().ContainValue(3.ToString());
        }
    }
}