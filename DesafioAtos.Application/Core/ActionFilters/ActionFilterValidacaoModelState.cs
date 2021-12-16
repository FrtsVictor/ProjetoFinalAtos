using DesafioAtos.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioAtos.Application.Core.ActionFilters
{
    public class ActionFilterValidacaoModelState : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            var listaDeErros = context.ModelState.SelectMany(sm => sm.Value?.Errors!)
                .Select(s => s.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(new FabricaResponse()
                    .Criar("Um ou mais campos invalidos!", listaDeErros));
            }
        }
    }
}