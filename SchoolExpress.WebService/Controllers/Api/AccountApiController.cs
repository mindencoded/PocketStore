using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;
using SchoolExpress.WebService.Models;

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
        public async Task<IHttpActionResult> Register([FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityUser identityUser = new IdentityUser
            {
                UserName = userModel.UserName
            };

            IUserRepository repository = Uow.GetRepository<IUserRepository>();
            IdentityResult result = await repository.CreateAsync(identityUser, userModel.Password);
            Uow.Commit();

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
    }
}