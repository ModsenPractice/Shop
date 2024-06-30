using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Shop.API.ActionFilters
{
    public class GrantTypeValidationFilterAttribute(params string[] grantTypes) :
        ActionFilterAttribute
    {
        private readonly string[] _grantTypes = grantTypes;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var type = context.HttpContext.Request.Form["grant_type"];

            if (string.IsNullOrEmpty(type) ||
                !_grantTypes.Contains<string>(type!))
            {
                context.Result = new BadRequestObjectResult("Invalid grant type.");
            }
        }
    }
}