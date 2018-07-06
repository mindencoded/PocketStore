﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/speakers")]
    public class SpeakerCrudApiController : CrudApiController<Speaker>
    {
        public SpeakerCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.speakers.get")]
        public override IEnumerable<Speaker> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.crud.speakers.get")]
        public override async Task<Speaker> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.speakers.put")]
        protected override async Task<HttpResponseMessage> Put(Speaker entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.crud.speakers.post")]
        public override async Task<HttpResponseMessage> Post(Speaker entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.speakers.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}