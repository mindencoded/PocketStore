using System;
using System.Web.Http;
using Common.Logging;
using Microsoft.AspNet.Identity;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly IUow Uow;
        protected ILog Log;

        protected BaseApiController(IUow uow)
        {
            Uow = uow;
            Log = LogManager.GetLogger(GetType());
            Console.Write(GetType());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Uow.Dispose();
            }

            base.Dispose(disposing);
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}