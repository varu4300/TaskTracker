using System.Net;

namespace TaskTracker.Api.Models.Responses
{
    public class BaseApiResponse<T>
    {
        public T? Result { get; set; }
        
        public string? Message { get; set; } = string.Empty;
        
        public HttpStatusCode StatusCode { get; set; }
    }
}

