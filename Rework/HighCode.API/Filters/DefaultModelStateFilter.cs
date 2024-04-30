using System.Text;
using HighCode.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HighCode.API.Filters;

public class DefaultModelStateFilter(ResponseFactory<SimpleResponse> responseFactory) : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext actionContext)
    {
        if (!actionContext.ModelState.IsValid)
        {
            var errorsSb = new StringBuilder();
            errorsSb.AppendLine("Ошибки:");
            foreach (var entry in actionContext.ModelState)
                errorsSb.AppendLine($"{entry.Key}: {string.Join(";", entry.Value.Errors.Select(e => e.ErrorMessage))}");
            actionContext.Result =
                new BadRequestObjectResult(responseFactory.BadRequestResponse(errorsSb.ToString()).Error);
        }
    }
}