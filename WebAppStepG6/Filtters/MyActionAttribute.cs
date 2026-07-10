using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppStepG6.Filtters
{
    public class MyActionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
