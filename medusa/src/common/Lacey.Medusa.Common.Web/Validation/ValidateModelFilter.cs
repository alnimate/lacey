using Microsoft.AspNetCore.Mvc.Filters;

namespace Lacey.Medusa.Common.Web.Validation
{
    public sealed class ValidateModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                throw new InvalidModelException(modelState.GetErrors());
            }

            base.OnActionExecuting(context);
        }
    }
}