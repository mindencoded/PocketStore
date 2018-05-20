using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/classrooms")]
    public class ClassRoomsApiController : CrudApiController<ClassRoom>
    {
        public ClassRoomsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }


        [Authorize(Roles = "api.classrooms.get")]
        public override IEnumerable<ClassRoom> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.classrooms.get")]
        public override ClassRoom Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.classrooms.put")]
        protected override HttpResponseMessage Put(ClassRoom entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "api.classrooms.post")]
        public override HttpResponseMessage Post(ClassRoom entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.classrooms.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}