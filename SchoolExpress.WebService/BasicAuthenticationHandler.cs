using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolExpress.WebService
{
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var credentials = ParseAuthorizationHeader(request);

            if (credentials != null)
            {
                // Check if the username and passowrd in credentials are valid against the ASP.NET membership.
                // If valid, the set the current principal in the request context
                var identity = new GenericIdentity(credentials.UserName);
                IPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.Request.User = principal;
            }

            return await base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (credentials == null)
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    response.Headers.Add("WWW-Authenticate",
                        string.Format("Basic realm=\"{0}\"", request.RequestUri.DnsSafeHost));
                }

                return response;
            });
        }

        protected virtual Credential ParseAuthorizationHeader(HttpRequestMessage request)
        {
            string authorizationHeader = null;
            var authorization = request.Headers.Authorization;
            if (authorization != null && authorization.Scheme == "Basic")
            {
                authorizationHeader = authorization.Parameter;
            }

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return null;
            }

            authorizationHeader = Encoding.Default.GetString(Convert.FromBase64String(authorizationHeader));
            var authenticationTokens = authorizationHeader.Split(':');
            if (authenticationTokens.Length < 2)
            {
                return null;
            }

            return new Credential()
            {
                UserName = authenticationTokens[0],
                Password = authenticationTokens[1]
            };
        }
    }
}