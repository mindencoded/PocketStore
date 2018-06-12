using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SchoolExpress.WebService.Providers;

namespace SchoolExpress.WebService.Filters
{
    public class JwtAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AuthenticationHeaderValue authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null && authRequest.Scheme.Equals("bearer", StringComparison.OrdinalIgnoreCase))
            {
                string token = authRequest.Parameter;
                if (!string.IsNullOrEmpty(token))
                {
                    string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                    ClaimsPrincipal principal = null;
                    try
                    {
                        principal = CustomJwtAuthorizationProvider.GetPrincipal(secretKey, token);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    if (principal != null)
                    {
                        ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                        if (identity != null)
                        {
                            Claim nameClaim = identity.FindFirst(ClaimTypes.Name);
                            Claim nameIdentifierClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                            IList<Claim> claims = new List<Claim>
                            {
                                nameClaim,
                                nameIdentifierClaim
                            };
                            IList<Claim> roleClaims = identity.FindAll(ClaimTypes.Role).ToList();
                            if (roleClaims.Any())
                            {
                                foreach (Claim roleClaim in roleClaims)
                                {
                                    claims.Add(roleClaim);
                                }
                            }

                            actionContext.RequestContext.Principal =
                                new ClaimsPrincipal(new ClaimsIdentity(claims, "Bearer"));
                        }
                    }
                }
            }

            //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            base.OnAuthorization(actionContext);
        }
    }
}