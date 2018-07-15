using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    public abstract class CrudApiController<T> : BaseApiController where T : class, IEntity
    {
        protected CrudApiController(IUow uow) : base(uow)
        {
        }

        [Route("")]
        [HttpGet]
        public virtual IEnumerable<T> Get()
        {
            return Uow.GetRepositoryForEntityType<T>().GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public virtual async Task<T> Get(object id)
        {
            T entity = await Uow.GetRepositoryForEntityType<T>().GetByIdAsync(id);
            if (entity != null)
                return entity;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [Route("")]
        [HttpPut]
        public virtual async Task<HttpResponseMessage> Put(T entity)
        {
            Uow.GetRepositoryForEntityType<T>().Update(entity);
            await Uow.CommitAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [Route("")]
        [HttpPost]
        public virtual async Task<HttpResponseMessage> Post(T entity)
        {
            Uow.GetRepositoryForEntityType<T>().Add(entity);
            await Uow.CommitAsync();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location =
                new Uri(Request.RequestUri.AbsoluteUri +
                        (entity.GetId() != null
                            ? "/" + string.Join("/", entity.GetId())
                            : ""));
            return response;
        }

        [Route("{id:int}")]
        [HttpDelete]
        public virtual async Task<HttpResponseMessage> Delete(object id)
        {
            Uow.GetRepositoryForEntityType<T>().Delete(id);
            await Uow.CommitAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}