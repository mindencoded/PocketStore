using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Models;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

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
            IUserRepository userRepository = _uow.GetRepository<IUserRepository>();
            User user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = Md5Tool.CreateUtf8Hash(model.Password)
            };
            userRepository.Add(user);
            await _uow.CommitAsync();
            return Ok();
        }
    }
}