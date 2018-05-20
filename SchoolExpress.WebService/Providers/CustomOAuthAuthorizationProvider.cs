using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Providers
{
    public class CustomOAuthAuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly ISchoolExpressUow _uow;

        public CustomOAuthAuthorizationProvider(ISchoolExpressUow uow)
        {
            _uow = uow;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return OnValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});
            using (IUserRepository userRepository = _uow.GetRepository<IUserRepository>())
            {
                IdentityUser user = await userRepository.FindUser(context.UserName, context.Password);
                if (user != null)
                {
                    IList<string> roles = await userRepository.GetRolesAsync(user.Id);
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    foreach (string role in roles)
                    {
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                    }
                    context.Validated(claimsIdentity);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                }
            }
        }
    }
}