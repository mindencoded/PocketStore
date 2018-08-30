using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    public abstract class CrudApiController<T> : BaseApiController where T : class, IEntity
    {
        protected CrudApiController(IUow uow) : base(uow)
        {
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}")]
        [HttpGet]
        public virtual QueryResponse<T> Get(int page, int pageSize, string orderBy)
        {
            if (pageSize < page)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize must be greater than page");
            }

            IList<string> orderByList = new List<string>();
            string[] orderByArray = orderBy.Split(',');
            foreach (string orderByItem in orderByArray)
            {
                if (!orderByItem.EndsWith(" ASC", StringComparison.OrdinalIgnoreCase) && !orderByItem.EndsWith(" DESC", StringComparison.OrdinalIgnoreCase))
                {
                    orderByList.Add(orderByItem + " ASC");
                }
                else
                {
                    orderByList.Add(orderByItem);
                }
            }
           
            IQueryable<T> query = Uow.GetRepositoryForEntityType<T>().GetAll();
            int total = query.Count();
            IEnumerable<T> items = query.OrderBy(string.Join(",", orderByList.ToArray())).Skip(page).Take(pageSize).ToList();
            return new QueryResponse<T>
            {
                Value = items,
                Total = total,
                Count = pageSize
            };
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