using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/useraccounts")]
    public class UserAccountsCrudApiController : CrudApiController<UserAccount>
    {
        public UserAccountsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.useraccounts.get")]
        public override QueryResponse<UserAccount> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.crud.useraccounts.get")]
        public override async Task<UserAccount> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.useraccounts.put")]
        public override async Task<HttpResponseMessage> Put(UserAccount entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.crud.useraccounts.post")]
        public override async Task<HttpResponseMessage> Post(UserAccount entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.useraccounts.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}
