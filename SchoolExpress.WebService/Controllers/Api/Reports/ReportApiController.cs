using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Reports
{
    public abstract class ReportApiController<TResponseModel> : BaseApiController where TResponseModel : class
    {
        protected ReportApiController(IUow uow) : base(uow)
        {
        }

        [Route("")]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get()
        {
            IQueryable<TResponseModel> query = CreateReport();
            IList<TResponseModel> list = await query.ToListAsync();
            int count = list.Count;
            dynamic response = new ExpandoObject();
            response.Value = list;
            response.Count = count;
            response.Total = count;
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}")]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            IQueryable<TResponseModel> query = CreateReport();
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
            IQueryable<TResponseModel> query = CreateReport();
            dynamic response = await query.CreateQuery(page, pageSize, orderBy, where, null);
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }


        [Route("{page:int}/{pageSize:int}/{orderBy}/{where}/{select}")]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            IQueryable<TResponseModel> query = CreateReport();
            dynamic response = await query.CreateQuery(page, pageSize, orderBy, where, select);
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }

        protected abstract IQueryable<TResponseModel> CreateReport();
    }

    public abstract class ReportApiController<TResponseModel, TRequestModel> : BaseApiController where TResponseModel : class where TRequestModel : class
    {
        protected ReportApiController(IUow uow) : base(uow)
        {
        }

        [Route("")]
        [HttpPost]
        public virtual async Task<HttpResponseMessage> Post([FromBody] TRequestModel model)
        {
            IQueryable<TResponseModel> query = CreateReport(model);
            IList<TResponseModel> list = await query.ToListAsync();
            int count = list.Count;
            dynamic response = new ExpandoObject();
            response.Value = list;
            response.Count = count;
            response.Total = count;
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}")]
        [HttpPost]
        public virtual async Task<HttpResponseMessage> Post(int page, int pageSize, string orderBy, [FromBody] TRequestModel model)
        {
            IQueryable<TResponseModel> query = CreateReport(model);
            dynamic response = await query.CreateQuery(page, pageSize, orderBy, null, null);
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }


        [Route("{page:int}/{pageSize:int}/{orderBy}/{where}")]
        [HttpPost]
        public virtual async Task<HttpResponseMessage> Post(int page, int pageSize, string orderBy, string where, [FromBody] TRequestModel model)
        {
            IQueryable<TResponseModel> query = CreateReport(model);
            dynamic response = await query.CreateQuery(page, pageSize, orderBy, where, null);
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }


        [Route("{page:int}/{pageSize:int}/{orderBy}/{where}/{select}")]
        [HttpPost]
        public virtual async Task<HttpResponseMessage> Post(int page, int pageSize, string orderBy, string where, string select, [FromBody] TRequestModel model)
        {
            IQueryable<TResponseModel> query = CreateReport(model);
            dynamic response = await query.CreateQuery(page, pageSize, orderBy, where, select);
            return new HttpResponseMessage
            {
                Content = new ObjectContent<dynamic>(response, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"))
            };
        }

        protected abstract IQueryable<TResponseModel> CreateReport(TRequestModel model);
    }
}
