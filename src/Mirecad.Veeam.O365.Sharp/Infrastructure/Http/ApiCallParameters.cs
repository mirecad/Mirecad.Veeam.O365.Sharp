using System.Collections.Generic;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public abstract class ApiCallParameters<T>
    {
        private Dictionary<string, T> _parameters;

        protected ApiCallParameters()
        {
            _parameters = new Dictionary<string, T>();
        }

        public ApiCallParameters<T> AddOptionalParameter(string key, T value)
        {
            if (value != null)
            {
                _parameters.Add(key, value);
            }
            return this;
        }

        public ApiCallParameters<T> AddMandatoryParameter(string key, T value)
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