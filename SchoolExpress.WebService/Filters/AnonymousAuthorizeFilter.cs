using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SchoolExpress.WebService.Filters
{
    public class AnonymousAuthorizeFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (IsUserAuthorized(filterContext))
            {
                base.OnAuthorization(filterContext);
            }
        }

        public bool IsUserAuthorized(HttpActionContext actionContext)
        {
            IList<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, "Anonymous")
            };

            AuthorizeAttribute authorizeAttribute = actionContext.ActionDescriptor
                .GetCustomAttributes<AuthorizeAttribute>(false).FirstOrDefault();
            string[] roles = { };
            if (authorizeAttribute != null)
            {
                roles = authorizeAttribute.Roles.Split(',');
            }
            else
            {
                authorizeAttribute = actionContext.ControllerContext.ControllerDescriptor
                    .GetCustomAttributes<AuthorizeAttribute>(false).FirstOrDefault();
                if (authorizeAttribute != null)
                {
                    roles = authorizeAttribute.Roles.Split(',');
                }
            }

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            actionContext.RequestContext.Principal =
                new ClaimsPrincipal(new ClaimsIdentity(claims));
            return true;
        }
    }
}