using System.Net;

namespace Infrastructure.ApiResponses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }

    public Response(T? data)
    {
        StatusCode = 200;
        Data = data;
        Message = "Success";
    }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
    }
}