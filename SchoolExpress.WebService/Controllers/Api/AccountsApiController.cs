using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;
using SchoolExpress.WebService.Models;
using SchoolExpress.WebService.Security;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/account")]
    public class AccountApiController : BaseApiController
    {
        public AccountApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        // POST api/Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] UserRegisterModel userRegisterModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityUser identityUser = new IdentityUser
            {
                UserName = userRegisterModel.UserName
            };

            IUserRepository repository = Uow.GetRepository<IUserRepository>();
            IdentityResult result = await repository.CreateAsync(identityUser, userRegisterModel.Password);
            Uow.Commit();

            if (result != null)
            {
                IHttpActionResult errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }
            }

            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login([FromBody] UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState,
                    Configuration.Formatters.JsonFormatter);
            }

            IUserRepository repository = Uow.GetRepository<IUserRepository>();
            IdentityUser user = await repository.FindUser(model.UserName, model.Password);
            if (user != null)
            {
                IList<string> roles = await repository.GetRolesAsync(user.Id);
                string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                AuthenticationModule authentication = new AuthenticationModule(secretKey);
                string token = authentication.GenerateTokenForUser(model.UserName, roles);
                return Request.CreateResponse(HttpStatusCode.OK, new {Token = token},
                    Configuration.Formatters.JsonFormatter);
            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized, Configuration.Formatters.JsonFormatter);
        }
    }
}