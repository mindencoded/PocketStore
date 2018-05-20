using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json.Linq;

namespace SchoolExpress.WebService
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            ModelStateDictionary modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                JObject errors = new JObject();
                foreach (string key in modelState.Keys)
                {
                    ModelState state = modelState[key];
                    if (state.Errors.Any())
                        errors[key] = state.Errors.First().ErrorMessage;
                }

                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}