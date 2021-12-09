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
        private readonly IFabricaResponse _responseFactory;
        public ErrorHandlerMiddleware(RequestDelegate next, IFabricaResponse responseFactory)
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
                var errorMessage = error.Message;

                switch (error)
                {
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case DataBaseConstraintException:
                    case BadRequestException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case DatabaseException:
                    case Exception e:
                    default:
                        response.StatusCode = 500;
                        errorMessage = defaultErrorMessage;
                        break;
                }

                var responseModel = _responseFactory.Create(errorMessage);
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}