using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the request
        Console.WriteLine($"[{DateTime.UtcNow}]   {context.Request.Method} instance:{context.Request.Path}   {context.Request.QueryString}   {context.Response.StatusCode}");
        // Console.WriteLine($"Request Method: {context.Request.Method}");
        // Console.WriteLine($"Request Path: {context.Request.Path}");
        // Console.WriteLine($"Request QueryString: {context.Request.QueryString}");
        // Console.WriteLine($"Request Protocol: {context.Request.Protocol}");
        // Console.WriteLine($"Request IP: {context.Connection.RemoteIpAddress}");

        // Call the next delegate/middleware in the pipeline
        await _next(context);

        // Log the response
        // Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
    }
}
