using System.Net;
using System.Text.Json;
using DesafioAtos.Application.Controllers;

namespace DesafioAtos.Application.Core.Middlewares.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IResponseFactory _responseFactory;
        public ErrorHandlerMiddleware(RequestDelegate next, IResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = _responseFactory.Create(error.Message);

                switch (error)
                {
                    // case SomeException e:
                    //     // custom application error
                    //     response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //     break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}