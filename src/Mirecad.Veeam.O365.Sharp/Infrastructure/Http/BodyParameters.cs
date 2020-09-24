namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public class BodyParameters : ApiCallParameters<object>
    {
        public new BodyParameters AddOptionalParameter(string key, object value)
        {
            return base.AddOptionalParameter(key, value) as BodyParameters;
        }

        public new BodyParameters AddMandatoryParameter(string key, object value)
        {
            return base.AddMandatoryParameter(key, value) as BodyParameters;
        }
    }
}