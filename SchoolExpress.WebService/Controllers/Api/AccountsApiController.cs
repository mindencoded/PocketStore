using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;
using SchoolExpress.WebService.Models;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/accounts")]
    public class AccountsApiController : BaseApiController
    {
        public AccountsApiController(ISchoolExpressUow uow) : base(uow)
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
    }
}