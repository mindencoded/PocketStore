using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SchoolExpress.WebService.Filters
{
    public class JwtAuthorizeAttribute : AuthorizationFilterAttribute
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
            AuthenticationHeaderValue authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null && authRequest.Scheme == "Bearer")
            {
                string token = authRequest.Parameter;
                if (!string.IsNullOrEmpty(token))
                {
                    string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                    ClaimsPrincipal principal = JwtAuthorizeModule.GetPrincipal(secretKey, token);
                    if (principal != null)
                    {
                        Claim nameIdentifierClaim = principal.Claims.FirstOrDefault(m => m.Type == "nameid");
                        Claim nameClaim = principal.Claims.FirstOrDefault(m => m.Type == "unique_name");
                        IList<Claim> roleClaims = principal.Claims.Where(m => m.Type == "role").ToList();
                        /*
                        Claim nameClaim = identity.FindFirst(ClaimTypes.Name);
                        Claim nameIdentifierClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                        IList<Claim> roleClaims = identity.FindAll(ClaimTypes.Role).ToList();
                        */
                        IList<Claim> claims = new List<Claim>
                        {
                            nameClaim,
                            nameIdentifierClaim
                        };
                        if (roleClaims.Any())
                        {
                            foreach (Claim roleClaim in roleClaims)
                            {
                                claims.Add(roleClaim);
                            }
                        }
                        actionContext.RequestContext.Principal =
                            new ClaimsPrincipal(new ClaimsIdentity(claims, "Bearer"));
                        return true;
                    }
                }
            }

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            return false;
        }
    }
}