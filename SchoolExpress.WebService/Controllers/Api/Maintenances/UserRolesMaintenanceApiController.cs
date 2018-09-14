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

namespace SchoolExpress.WebService.Controllers.Api.Maintenances
{
    [RoutePrefix("api/maintenances/userroles")]
    public class UserRolesMaintenanceApiController: MaintenanceApiController<UserRole>
    {
        public UserRolesMaintenanceApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
        
        [HttpGet]
        [Authorize(Roles = "api.maintenances.userroles.get")]
        [Route("{userId:int}/{roleId:int}")]
        public async Task<HttpResponseMessage> Get(int userId, int roleId)
        {
            UserRole userRole =
                await Uow.GetRepository<IUserRoleRepository>().FindAsync(userId, roleId);
            if (userRole != null)
                return Request.CreateResponse(HttpStatusCode.OK, userRole, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"));
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
        
        [HttpDelete]
        [Authorize(Roles = "api.maintenances.userroles.delete")]
        [Route("{userId:int}/{roleId:int}")]
        public async Task<HttpResponseMessage> Delete(int userId, int roleId)
        {
            await Uow.GetRepository<IUserRoleRepository>().DeleteAsync(userId, roleId);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        
        [Authorize(Roles = "api.maintenances.userroles.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.maintenances.userroles.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            return base.Get(page, pageSize, orderBy, where);
        }
        
        [Authorize(Roles = "api.maintenances.userroles.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            return base.Get(page, pageSize, orderBy, where, select);
        }

        public override Task<HttpResponseMessage> Get(object id)
        {
            throw new NotImplementedException();
        }


        [Authorize(Roles = "api.maintenances.userroles.put")]
        public override async Task<HttpResponseMessage> Put(UserRole entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.maintenances.userroles.post")]
        public override async Task<HttpResponseMessage> Post(UserRole entity)
        {
            return await base.Post(entity);
        }
        
        [Authorize(Roles = "api.maintenances.userroles.patch")]
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