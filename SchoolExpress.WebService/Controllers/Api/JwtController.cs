using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.WebService.Models;
using SchoolExpress.WebService.Providers;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("jwt")]
    public class JwtController : BaseApiController
    {

        private ISchoolExpressUow _uow;
        public JwtController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Post([FromBody] UserLoginModel model)
        {
            UserManager<IdentityUser> userManager = _uow.UserManager();
            IdentityUser user = await userManager.FindAsync(model.UserName, model.Password);
            if (user != null)
            {
                IEnumerable<string> roles = await userManager.GetRolesAsync(user.Id);
                string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                double tokenExpiration = double.Parse(ConfigurationManager.AppSettings["TokenExpirationMinutes"]);
                string token =
                    new CustomJwtAuthorizationProvider().GenerateToken(secretKey, user.Id, user.UserName, roles,
                        tokenExpiration);
                return Ok(new
                {
                    access_token = token,
                    token_type = "bearer",
                    expires_in = TimeSpan.FromMinutes(tokenExpiration).TotalSeconds
                });
            }

            return Unauthorized();
        }
    }
}