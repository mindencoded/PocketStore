using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Filters
{
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }

        public bool AllowMultiple { get; set; }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            if (authorization != null && authorization.Scheme == "Bearer")
            {
                string token = authorization.Parameter;
                if (!string.IsNullOrEmpty(token))
                {
                    string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                    ClaimsPrincipal principal = JwtAuthenticationModule.GetPrincipal(secretKey, token);
                    if (principal != null)
                    {
                        ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
                        if (identity == null || !identity.IsAuthenticated)
                        {
                            context.ErrorResult = new HttpActionResult(HttpStatusCode.Unauthorized, request);
                            return null;
                        }
                        Claim nameClaim = identity.FindFirst(ClaimTypes.Name);
                        Claim nameIdentifierClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                        IList<Claim> roleClaims = identity.FindAll(ClaimTypes.Role).ToList();
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
                        context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Bearer"));
                        return null;
                    }
                }
            }

            context.ErrorResult = new HttpActionResult(HttpStatusCode.Unauthorized, request);
            return null;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter;

            if (!string.IsNullOrEmpty(Realm))
            {
                parameter = "realm=\"" + Realm + "\"";
            }
            else
            {
                parameter = "realm=\"" + context.Request.RequestUri.Host + "\"";
            }

            context.Result =
                new AddChallengeOnUnauthorizedResult(new AuthenticationHeaderValue("Bearer", parameter),
                    context.Result);
        }

        private class AddChallengeOnUnauthorizedResult : IHttpActionResult
        {
            public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
            {
                Challenge = challenge;
                InnerResult = innerResult;
            }

            public AuthenticationHeaderValue Challenge { get; }

            public IHttpActionResult InnerResult { get; }

            public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response = await InnerResult.ExecuteAsync(cancellationToken);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Only add one challenge per authentication scheme.
                    if (response.Headers.WwwAuthenticate.All(h => h.Scheme != Challenge.Scheme))
                    {
                        response.Headers.WwwAuthenticate.Add(Challenge);
                    }
                }

                return response;
            }
        }

    }
}