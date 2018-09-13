using System;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Cruds
{
    public abstract class CrudApiController<T> : BaseApiController where T : class
    {
        protected CrudApiController(IUow uow) : base(uow)
        {
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}")]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            IQueryable<T> query = Uow.GetRepositoryForEntityType<T>().GetQueryable().AsNoTracking();
            dynamic response = await query.CreateQuery(page, pageSize, orderBy, null, null);           
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}/{where}")]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            IQueryable<T> query = Uow.GetRepositoryForEntityType<T>().GetQueryable().AsNoTracking();
            dynamic response = await query.CreateQuery(page, pageSize, orderBy, where, null);  
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}/{where}/{select}")]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where,
            string select)
        {
            IQueryable<T> query = Uow.GetRepositoryForEntityType<T>().GetQueryable().AsNoTracking();
            dynamic response = await query.CreateQuery(page, pageSize, orderBy, where, select);  
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }
        
        [Route("{id}")]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get(object id)
        {
            T entity = await Uow.GetRepositoryForEntityType<T>().FindAsync(id);
            if (entity != null)
            {
                return new HttpResponseMessage
                {
                    Content = new ObjectContent<T>(entity, new JsonMediaTypeFormatter(),
                        new MediaTypeHeaderValue("application/json"))
                };
            }

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
            if (entity is IEntity)
            {
                response.Headers.Location =
                    new Uri(Request.RequestUri.AbsoluteUri +
                            (((IEntity) entity).GetId() != null
                                ? "/" + string.Join("/", ((IEntity) entity).GetId())
                                : ""));
            }

            return response;
        }

        [Route("")]
        [HttpPatch]
        public virtual async Task<HttpResponseMessage> Patch([FromBody] string json)
        {
            ExpandoObject expandoObject = JsonConvert.DeserializeObject<ExpandoObject>(json);
            Uow.ValidateOnSaveEnabled(false);
            Uow.GetRepositoryForEntityType<T>().Update(expandoObject);
            await Uow.CommitAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
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