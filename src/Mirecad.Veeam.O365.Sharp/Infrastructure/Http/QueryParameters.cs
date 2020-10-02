namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public class QueryParameters : ApiCallParameters<string>
    {
        public QueryParameters AddOptionalParameter(string key, object value)
        {
            return base.AddOptionalApiParameter(key, value?.ToString()) as QueryParameters;
        }

        public QueryParameters AddMandatoryParameter(string key, object value)
        {
            return base.AddMandatoryApiParameter(key, value?.ToString()) as QueryParameters;
        }
    }
}