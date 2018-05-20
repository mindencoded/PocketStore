using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
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
        public virtual T Get(object id)
        {
            T entity = Uow.GetRepositoryForEntityType<T>().GetById(id);
            if (entity != null)
                return entity;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [Route("")]
        [HttpPut]
        protected virtual HttpResponseMessage Put(T entity)
        {
            Uow.GetRepositoryForEntityType<T>().Update(entity);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [Route("")]
        [HttpPost]
        public virtual HttpResponseMessage Post(T entity)
        {
            Uow.GetRepositoryForEntityType<T>().Add(entity);
            Uow.Commit();
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
        public virtual HttpResponseMessage Delete(object id)
        {
            Uow.GetRepositoryForEntityType<T>().Delete(id);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}