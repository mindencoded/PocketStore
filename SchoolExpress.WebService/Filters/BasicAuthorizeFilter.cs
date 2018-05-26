using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.Filters
{
    public class BasicAuthorizeFilter : ActionFilterAttribute
    {
        private readonly UserManager<IdentityUser> _manager;

        public BasicAuthorizeFilter(UserManager<IdentityUser> manager)
        {
            _manager = manager;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            AuthenticationHeaderValue authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null && authRequest.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
            {
                string token = authRequest.Parameter;
                if (!string.IsNullOrEmpty(token))
                {
                    string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    string username = decodedToken.Substring(0, decodedToken.IndexOf(":", StringComparison.Ordinal));
                    string password = decodedToken.Substring(decodedToken.IndexOf(":", StringComparison.Ordinal) + 1);
                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        IdentityUser user = _manager.Find(username, password);
                        if (user != null)
                        {
                            IList<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.UserName),
                                new Claim(ClaimTypes.NameIdentifier, user.Id)
                            };
                            AuthorizeAttribute authorizeAttribute = actionContext.ActionDescriptor
                                .GetCustomAttributes<AuthorizeAttribute>(true)
                                .FirstOrDefault();
                            if (authorizeAttribute != null)
                            {
                                string[] roles = authorizeAttribute.Roles.Split(',');
                                foreach (var role in roles)
                                {
                                    if (_manager.IsInRole(user.Id, role))
                                    {
                                        claims.Add(new Claim(ClaimTypes.Role, role));
                                    }
                                }
                            }

                            actionContext.RequestContext.Principal =
                                new ClaimsPrincipal(new ClaimsIdentity(claims, "Basic"));
                        }
                    }
                }
            }
            //actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            base.OnActionExecuting(actionContext);
        }
    }
}