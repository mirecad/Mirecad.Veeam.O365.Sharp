using System;
using System.Runtime.Serialization;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public class ApiCallException : Exception
    {
        public ApiCallException()
        {
        }

        protected ApiCallException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ApiCallException(string message) : base(message)
        {
        }

        public ApiCallException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}