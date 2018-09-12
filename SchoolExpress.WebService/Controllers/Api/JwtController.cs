using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Models;
using SchoolExpress.WebService.Providers;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

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
            IUserRepository userRepository = _uow.GetRepository<IUserRepository>();
            string hash = Md5Tool.CreateUtf8Hash(model.Password);
            dynamic user = await userRepository.GetQueryable().AsNoTracking().Include(x => x.UserRoles.Select(y => y.Role)).Where(x => x.UserName == model.UserName && x.Password == hash).Select(x => new
            {
                x.UserName,
                Roles = x.UserRoles.Select(y => y.Role.Name)
            }).FirstOrDefaultAsync();
            if (user != null)
            {
               
                string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                double tokenExpiration = double.Parse(ConfigurationManager.AppSettings["TokenExpirationMinutes"]);
                string token =  new CustomJwtAuthorizationProvider().GenerateToken(secretKey, user.UserName, user.Roles, tokenExpiration);
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