using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;
using SchoolExpress.WebService.Models;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("account")]
    public class AccountApiController : BaseApiController
    {
        public AccountApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] UserRegisterModel model)
        {
            IdentityUser identityUser = new IdentityUser
            {
                UserName = model.UserName
            };

            IUserRepository repository = Uow.GetRepository<IUserRepository>();
            await repository.CreateAsync(identityUser, model.Password);
            Uow.Commit();
            return Ok();
        }
    }

}