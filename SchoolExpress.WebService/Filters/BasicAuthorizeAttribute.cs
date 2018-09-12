using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class BasicAuthorizeAttribute : AuthorizationFilterAttribute
    {
        private readonly ISchoolExpressUow _uow;

        public BasicAuthorizeAttribute(ISchoolExpressUow uow)
        {
            _uow = uow;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
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
                        IUserRepository userRepository = _uow.GetRepository<IUserRepository>();
                        string hash = Md5Tool.CreateUtf8Hash(password);
                        dynamic user = userRepository.GetQueryable().AsNoTracking().Include(x => x.UserRoles.Select(y => y.Role)).Where(x => x.UserName == username && x.Password == hash).Select(x => new
                        {
                            x.UserName,
                            Roles = x.UserRoles.Select(y => y.Role.Name)
                        }).FirstOrDefault();
                        if (user != null)
                        {
                            IList<Claim> claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.UserName),
                                new Claim(ClaimTypes.NameIdentifier, user.UserName)
                            };
                            AuthorizeAttribute authorizeAttribute = actionContext.ActionDescriptor
                                .GetCustomAttributes<AuthorizeAttribute>(true)
                                .FirstOrDefault();
                            if (authorizeAttribute != null)
                            {
                                string[] roles = authorizeAttribute.Roles.Split(',');
                                foreach (string role in roles)
                                {
                                    if (user.Roles.Contains(role))
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
            base.OnAuthorization(actionContext);
        }
    }
}