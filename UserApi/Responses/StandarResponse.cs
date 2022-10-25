using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UserApi.Responses
{
    public class StandarResponse<T> where T : class
    {
        public StandarResponse(HttpStatusCode statusCode, T data, string? message="")
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }

        //public IActionResult Result
        //{
        //    get { return ActionResult<T> }
        //}
    }
}
