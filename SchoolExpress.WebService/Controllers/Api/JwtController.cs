using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;
using SchoolExpress.WebService.Filters;
using SchoolExpress.WebService.Models;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IUserRepository repository = Uow.GetRepository<IUserRepository>();
            IdentityUser user = await repository.FindUser(model.UserName, model.Password);
            if (user != null)
            {
                IEnumerable<string> roles = await repository.GetRolesAsync(user.Id);
                string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                double tokenExpiration = double.Parse(ConfigurationManager.AppSettings["TokenExpiration"]);
                string token = JwtAuthenticationModule.GenerateToken(secretKey, user.Id, user.UserName, roles, tokenExpiration);
                //string token = JwtAuthorizeModule.GenerateTokenForUser(secretKey, user.Id, user.UserName, roles, tokenExpiration);
                return Ok(new {Token = token});
            }
            return Unauthorized();
        }

        /*[HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<HttpResponseMessage> Post([FromBody] UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState, Configuration.Formatters.JsonFormatter);
            }
            IUserRepository repository = Uow.GetRepository<IUserRepository>();
            IdentityUser user = await repository.FindUser(model.UserName, model.Password);
            if (user != null)
            {
                IList<string> roles = await repository.GetRolesAsync(user.Id);
                string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                double tokenExpiration = double.Parse(ConfigurationManager.AppSettings["TokenExpiration"]);
                string token = JwtAuthenticationModule.GenerateToken(secretKey, user.Id, user.UserName, roles.ToArray(), tokenExpiration);
                //string token = JwtAuthorizeModule.GenerateTokenForUser(secretKey, user.Id, user.UserName, roles, tokenExpiration);
                return Request.CreateResponse(HttpStatusCode.OK, new { Token = token }, Configuration.Formatters.JsonFormatter);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized, Configuration.Formatters.JsonFormatter);
        }*/
    }
}