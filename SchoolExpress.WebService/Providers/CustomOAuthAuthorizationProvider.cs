using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

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
            return Task.FromResult<object>(null);
            //return OnValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});
            IUserRepository userRepository = _uow.GetRepository<IUserRepository>();
            string hash = Md5Tool.CreateUtf8Hash(context.Password);
            dynamic user = await userRepository.GetQueryable().AsNoTracking().Include(x => x.UserRoles.Select(y => y.Role)).Where(x => x.UserName == context.UserName && x.Password == hash).Select(x => new
            {
                x.UserName,
                Roles = x.UserRoles.Select(y => y.Role.Name)
            }).FirstOrDefaultAsync();
            if (user != null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                //identity.AddClaim(new Claim("sub", user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserName));
                foreach (string role in user.Roles)
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