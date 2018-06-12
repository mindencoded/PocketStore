using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;
using SchoolExpress.WebService.Models;
using SchoolExpress.WebService.Providers;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("jwt")]
    public class JwtController : BaseApiController
    {
        public JwtController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Post([FromBody] UserLoginModel model)
        {
            IUserRepository repository = Uow.GetRepository<IUserRepository>();
            IdentityUser user = await repository.FindUser(model.UserName, model.Password);
            if (user != null)
            {
                IEnumerable<string> roles = await repository.GetRolesAsync(user.Id);
                string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                double tokenExpiration = double.Parse(ConfigurationManager.AppSettings["TokenExpirationMinutes"]);
                string token =
                    CustomJwtAuthorizationProvider.GenerateToken(secretKey, user.Id, user.UserName, roles,
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