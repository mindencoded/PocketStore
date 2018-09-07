using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Cruds
{
    [Authorize]
    [RoutePrefix("api/cruds/careerscheduledetails")]
    public class CareerScheduleDetailsCrudApiController : CrudApiController<CareerScheduleDetail>
    {
        public CareerScheduleDetailsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.cruds.careerscheduledetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.cruds.careerscheduledetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            return base.Get(page, pageSize, orderBy, where);
        }
        
        [Authorize(Roles = "api.cruds.careerscheduledetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            return base.Get(page, pageSize, orderBy, where, select);
        }

        [Authorize(Roles = "api.cruds.careerscheduledetails.get")]
        public override async Task<HttpResponseMessage> Get(object id)
        {
            return await base.Get(id);
        }

        [Authorize(Roles = "api.cruds.careerscheduledetails.put")]
        public override async Task<HttpResponseMessage> Put(CareerScheduleDetail entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.cruds.careerscheduledetails.post")]
        public override async Task<HttpResponseMessage> Post(CareerScheduleDetail entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.cruds.careerscheduledetails.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}