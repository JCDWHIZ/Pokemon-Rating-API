// using System;
// using System;
// using System;
// using System.IO;
// using System.Text.Json;
// using System.Text.Json;
// using System.Text.Json.Serialization;
// using System.Text.Json.Serialization;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;

// public class ApiResponse<T>
// {
//     [JsonPropertyName("isSuccess")]
//     public bool IsSuccess { get; set; }

//     [JsonPropertyName("timestamp")]
//     public DateTime Timestamp { get; set; }

//     [JsonPropertyName("statusCode")]
//     public int StatusCode { get; set; }

//     [JsonPropertyName("data")]
//     public T Data { get; set; }

//     public ApiResponse(bool isSuccess, int statusCode, T data)
//     {
//         IsSuccess = isSuccess;
//         Timestamp = DateTime.UtcNow;
//         StatusCode = statusCode;
//         Data = data;
//     }
// }

// public class ApiResponseConverter<T> : JsonConverter<ApiResponse<T>>
// {
//     public override ApiResponse<T> Read(
//         ref Utf8JsonReader reader,
//         Type typeToConvert,
//         JsonSerializerOptions options
//     )
//     {
//         // For this example, we do not handle deserialization
//         throw new NotImplementedException();
//     }

//     public override void Write(
//         Utf8JsonWriter writer,
//         ApiResponse<T> value,
//         JsonSerializerOptions options
//     )
//     {
//         writer.WriteStartObject();
//         writer.WriteBoolean("isSuccess", value.IsSuccess);
//         writer.WriteString("timestamp", value.Timestamp.ToString("o")); // ISO 8601 format
//         writer.WriteNumber("statusCode", value.StatusCode);
//         writer.WritePropertyName("data");

//         JsonSerializer.Serialize(writer, value.Data, options); // Serialize the "data" part
//         writer.WriteEndObject();
//     }
// }

// public class ApiResponseMiddleware
// {
//     private readonly RequestDelegate _next;

//     public ApiResponseMiddleware(RequestDelegate next)
//     {
//         _next = next;
//     }

//     public async Task InvokeAsync(HttpContext context)
//     {
//         // Capture the original response body
//         var originalBodyStream = context.Response.Body;

//         using (var memoryStream = new MemoryStream())
//         {
//             context.Response.Body = memoryStream;

//             await _next(context);

//             // Determine if the request was successful (status codes in 2xx-3xx range)
//             bool isSuccess =
//                 context.Response.StatusCode >= 200 && context.Response.StatusCode < 400;

//             // Prepare the API response wrapper
//             var responseBody = await FormatResponse(memoryStream);
//             var apiResponse = new ApiResponse<object>(
//                 isSuccess,
//                 context.Response.StatusCode,
//                 responseBody
//             );

//             // Serialize the response using System.Text.Json and the custom JsonConverter
//             var options = new JsonSerializerOptions();
//             options.Converters.Add(new ApiResponseConverter<object>());

//             var jsonResponse = JsonSerializer.Serialize(apiResponse, options);

//             // Set the response body and content type
//             context.Response.ContentType = "application/json";
//             context.Response.ContentLength = jsonResponse.Length;

//             await context.Response.WriteAsync(jsonResponse);
//         }
//     }

//     private async Task<object> FormatResponse(Stream bodyStream)
//     {
//         // Rewind the stream and read the content
//         bodyStream.Seek(0, SeekOrigin.Begin);
//         var responseBody = await new StreamReader(bodyStream).ReadToEndAsync();

//         // Try to parse the response body as JSON
//         if (!string.IsNullOrWhiteSpace(responseBody))
//         {
//             try
//             {
//                 return JsonSerializer.Deserialize<object>(responseBody);
//             }
//             catch
//             {
//                 // If it's not valid JSON, return it as plain text
//                 return responseBody;
//             }
//         }

//         return null;
//     }
// }

using System.Net;
using System.Text.Json;

public interface ICustomApiException
{
    HttpStatusCode HttpStatus { get; }
    string HttpMessage { get; }
}

public class ExampleApiException : Exception, ICustomApiException
{
    public HttpStatusCode HttpStatus => HttpStatusCode.Forbidden;
    public string HttpMessage => "Resource cannot be accessed.";

    public ExampleApiException(string message)
        : base(message) { }
}

public class ErrorDto
{
    public int Status { get; set; }
    public string Message { get; set; }
}

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var httpStatus = HttpStatusCode.InternalServerError;
            var httpMessage = "Internal Server Error";

            if (ex is ICustomApiException customException)
            {
                httpStatus = customException.HttpStatus;
                httpMessage = customException.HttpMessage;
            }

            context.Response.StatusCode = (int)httpStatus;
            context.Response.ContentType = "application/json";

            var error = new ErrorDto() { Status = (int)httpStatus, Message = httpMessage };

            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
