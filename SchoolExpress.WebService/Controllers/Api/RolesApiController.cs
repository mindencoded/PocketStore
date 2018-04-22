using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/roles")]
    public class RolesApiController : CrudApiController<Role>
    {
        public RolesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "SelectRole")]
        public override IEnumerable<Role> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectRole")]
        public override Role Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateRole")]
        protected override HttpResponseMessage Put(Role entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertRole")]
        public override HttpResponseMessage Post(Role entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteRole")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }

    }
}