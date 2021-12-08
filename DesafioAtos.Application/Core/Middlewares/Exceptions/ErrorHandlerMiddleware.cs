using System.Net;
using System.Text.Json;
using DesafioAtos.Application.Controllers;
using DesafioAtos.Infra.Exceptions;
using DesafioAtos.Service.Exceptions;

namespace DesafioAtos.Application.Core.Middlewares.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private const string defaultErrorMessage = "Internal server error!!!";

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
                    case DataBaseConstraintException:
                    case BadRequestException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case Exception e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}