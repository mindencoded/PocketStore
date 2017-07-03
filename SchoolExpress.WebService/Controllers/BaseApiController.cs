using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.Logging;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    public abstract class BaseApiController<T> : ApiController where T : class, IEntityBase
    {
        private readonly IUow _uow;
        protected ILog Log;

        protected BaseApiController(IUow uow)
        {
            _uow = uow;
            Log = LogManager.GetLogger(GetType());
        }

        [Route("")]
        public virtual IEnumerable<T> Get()
        {
            return _uow.GetGenericRepository<T>().GetAll();
        }

        [Route("{id:int}")]
        public virtual T Get(int id)
        {
            var entity = _uow.GetGenericRepository<T>().GetById(id);
            if (entity != null)
                return entity;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [Route("")]
        public virtual HttpResponseMessage Put(T entity)
        {
            _uow.GetGenericRepository<T>().Update(entity);
            _uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [Route("")]
        public virtual HttpResponseMessage Post(T entity)
        {
            _uow.GetGenericRepository<T>().Add(entity);
            _uow.Commit();
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location =
                new Uri(Request.RequestUri.AbsoluteUri +
                        (entity.IdentityKey() != null
                            ? "/" + string.Join("/", entity.IdentityKey())
                            : ""));
            return response;
        }

        [Route("{id:int}")]
        public virtual HttpResponseMessage Delete(int id)
        {
            _uow.GetGenericRepository<T>().Delete(id);
            _uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}