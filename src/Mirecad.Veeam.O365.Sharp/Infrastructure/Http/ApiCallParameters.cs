using System.Collections.Generic;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public abstract class ApiCallParameters<T> where T : class
    {
        private Dictionary<string, T> _parameters;

        protected ApiCallParameters()
        {
            _parameters = new Dictionary<string, T>();
        }

        protected ApiCallParameters<T> AddNullApiParameter(string key)
        {
            _parameters.Add(key, null);
            return this;
        }

        protected ApiCallParameters<T> AddOptionalApiParameter(string key, T value)
        {
            if (value != null)
            {
                _parameters.Add(key, value);
            }
            return this;
        }

        protected ApiCallParameters<T> AddMandatoryApiParameter(string key, T value)
        {
            ParameterValidator.ValidateNotNull(value, key);
            _parameters.Add(key, value);
            return this;
        }

        public Dictionary<string, T> GetParameters()
        {
            return _parameters;
        }
    }
}