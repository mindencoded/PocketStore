using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/classrooms")]
    public class ClassRoomsApiController : CrudApiController<ClassRoom>
    {
        public ClassRoomsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }


        [Authorize(Roles = "SelectClassRoom")]
        public override IEnumerable<ClassRoom> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectClassRoom")]
        public override ClassRoom Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateClassRoom")]
        protected override HttpResponseMessage Put(ClassRoom entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertClassRoom")]
        public override HttpResponseMessage Post(ClassRoom entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteClassRoom")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }
    }
}