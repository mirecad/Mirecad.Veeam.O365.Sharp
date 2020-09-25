using System.Net;

namespace Mirecad.Veeam.O365.Sharp.Infrastructure.Http
{
    public class ApiCallResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string StringContent { get; set; }
    }

    public class ApiCallResponse<T> : ApiCallResponse
    {
        public T Content { get; set; }
    }
}