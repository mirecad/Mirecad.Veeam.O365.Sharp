namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public class BodyParameters : ApiCallParameters<object>
    {
        public BodyParameters AddOptionalParameter(string key, object value)
        {
            return base.AddOptionalApiParameter(key, value) as BodyParameters;
        }

        public BodyParameters AddMandatoryParameter(string key, object value)
        {
            return base.AddMandatoryApiParameter(key, value) as BodyParameters;
        }

        public BodyParameters AddNullParameter(string key)
        {
            return base.AddNullApiParameter(key) as BodyParameters;
        }
    }
}