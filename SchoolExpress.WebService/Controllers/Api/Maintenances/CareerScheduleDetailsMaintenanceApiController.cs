﻿using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Maintenances
{
    [Authorize]
    [RoutePrefix("api/maintenances/careerscheduledetails")]
    public class CareerScheduleDetailsMaintenanceApiController : MaintenanceApiController<CareerScheduleDetail>
    {
        public CareerScheduleDetailsMaintenanceApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.maintenances.careerscheduledetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.maintenances.careerscheduledetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            return base.Get(page, pageSize, orderBy, where);
        }
        
        [Authorize(Roles = "api.maintenances.careerscheduledetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            return base.Get(page, pageSize, orderBy, where, select);
        }

        [Authorize(Roles = "api.maintenances.careerscheduledetails.get")]
        public override async Task<HttpResponseMessage> Get(object id)
        {
            return await base.Get(id);
        }

        [Authorize(Roles = "api.maintenances.careerscheduledetails.put")]
        public override async Task<HttpResponseMessage> Put(CareerScheduleDetail entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.maintenances.careerscheduledetails.post")]
        public override async Task<HttpResponseMessage> Post(CareerScheduleDetail entity)
        {
            return await base.Post(entity);
        }
        
        [Authorize(Roles = "api.maintenances.careerscheduledetails.patch")]
        public override async Task<HttpResponseMessage> Patch([FromBody] string json)
        {
            return await base.Patch(json);
        }

        [Authorize(Roles = "api.maintenances.careerscheduledetails.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}