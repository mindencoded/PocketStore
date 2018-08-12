using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolExpress.WebService.Models;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("account")]
    public class AccountApiController : BaseApiController
    {
        private ISchoolExpressUow _uow;
        public AccountApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody] UserRegisterModel model)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = model.UserName
            };
            UserManager<IdentityUser> userManager = _uow.UserManager();
            await userManager.CreateAsync(user, model.Password);
            _uow.Commit();
            return Ok();
        }
    }
}