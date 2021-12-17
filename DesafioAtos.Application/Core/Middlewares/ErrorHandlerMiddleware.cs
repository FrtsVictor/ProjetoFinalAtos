using System.Net;
using System.Text.Json;
using DesafioAtos.Application.Controllers;
using DesafioAtos.Domain.Exceptions;
using DesafioAtos.Service.Exceptions;
using DesafioAtos.Infra.Exceptions;

namespace DesafioAtos.Application.Core.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private const string DEFAULT_ERROR_MESSAGE = "Internal server error!!!";

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
                    case KeyNotFoundException:
                        response.StatusCode = (int) HttpStatusCode.NotFound;
                        break;

                    case DataBaseConstraintException:
                    case InvalidEnumException:
                    case BadRequestException:
                        response.StatusCode = (int) HttpStatusCode.BadRequest;
                        break;

                    case DatabaseException:
                    case { }:
                        response.StatusCode = 500;
                        errorMessage = DEFAULT_ERROR_MESSAGE;
                        break;
                }

                var responseModel = _responseFactory.Criar(errorMessage);
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}