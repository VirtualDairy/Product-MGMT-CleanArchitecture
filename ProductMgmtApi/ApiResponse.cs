using System.Net;

namespace ProductMgmtApi
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } 
        public string Message { get; set; }
        public TimeSpan CallDuration { get; set; }

        public object Data { get; set; }
    }
}
