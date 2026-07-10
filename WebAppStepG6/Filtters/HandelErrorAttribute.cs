using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppStepG6.Filtters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //change response exception==>
            //ContentResult result = new ContentResult();
            //result.Content = context.Exception.Message;// "exception happen";

            ViewResult result = new ViewResult();
            result.ViewName = "Error";
            context.Result = result;
        }
    }
}
