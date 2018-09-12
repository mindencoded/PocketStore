using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Cruds
{
    [RoutePrefix("api/cruds/useraccounts")]
    public class UserAccountsCrudApiController : CrudApiController<UserAccount>
    {
        public UserAccountsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
        
        [HttpGet]
        [Authorize(Roles = "api.cruds.useraccounts.get")]
        [Route("{userId:int}/{personId:int}")]
        public async Task<HttpResponseMessage> Get(int userId, int personId)
        {
            UserAccount userAccount =
                await Uow.GetRepository<IUserAccountRepository>().FindAsync(userId, personId);
            if (userAccount != null)
                return Request.CreateResponse(HttpStatusCode.OK, userAccount, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"));
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        
        [HttpDelete]
        [Authorize(Roles = "api.cruds.useraccounts.delete")]
        [Route("{userId:int}/{personId:int}")]
        public async Task<HttpResponseMessage> Delete(int userId, int personId)
        {
            await Uow.GetRepository<IUserAccountRepository>().DeleteAsync(userId, personId);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [Authorize(Roles = "api.cruds.useraccounts.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.cruds.useraccounts.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            return base.Get(page, pageSize, orderBy, where);
        }
        
        [Authorize(Roles = "api.cruds.useraccounts.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            return base.Get(page, pageSize, orderBy, where, select);
        }

        public override Task<HttpResponseMessage> Get(object id)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "api.cruds.useraccounts.put")]
        public override async Task<HttpResponseMessage> Put(UserAccount entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.cruds.useraccounts.post")]
        public override async Task<HttpResponseMessage> Post(UserAccount entity)
        {
            return await base.Post(entity);
        }
        
        [Authorize(Roles = "api.cruds.useraccounts.patch")]
        public override async Task<HttpResponseMessage> Patch([FromBody] string json)
        {
            return await base.Patch(json);
        }

        public override Task<HttpResponseMessage> Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
