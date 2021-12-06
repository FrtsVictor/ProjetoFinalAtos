using System.Collections.Generic;
using System.Linq;
using DesafioAtos.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DesafioAtos.Application.ActionFilters.ValidateModel
{
    public class ValidateModelActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> errorList = context.ModelState.SelectMany(sm => sm.Value?.Errors!)
                     .Select(s => s.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(new ResponseFactory()
                    .Create("One or more fields are invalid!", errorList));
            }
        }
    }
}