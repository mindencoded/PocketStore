using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace SchoolExpress.WebService.Providers
{
    public class CustomOAuthAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UserManager<IdentityUser> _manager;

        public CustomOAuthAuthorizationProvider(UserManager<IdentityUser> manager)
        {
            _manager = manager;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
            //return OnValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});
            IdentityUser user = await _manager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                IList<string> roles = await _manager.GetRolesAsync(user.Id);
                ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                foreach (string role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    IssuedUtc = DateTimeOffset.Now,
                    ExpiresUtc = DateTimeOffset.Now.AddMinutes(double.Parse(ConfigurationManager.AppSettings["TokenExpirationMinutes"]))
                });
                context.Validated(ticket);
            }
            else
            {
                context.Rejected();
                //context.SetError("invalid_grant", "The user name or password is incorrect.");
            }
        }
    }
}