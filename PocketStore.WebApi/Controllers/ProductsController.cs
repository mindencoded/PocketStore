using Common.Logging;
using PocketStore.Domain;
using PocketStore.Infrastructure.DataContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace PocketStore.WebApi.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class ProductsController : ApiController
    {
        private PocketStoreDataContext _db;
        private ILog _log;

        public ProductsController()
        {
            _log = LogManager.GetLogger(GetType());
            _db = new PocketStoreDataContext();
        }

        [HttpGet]
        [Route("products")]
        public HttpResponseMessage GetProducts()
        {
            var result = _db.Products.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories")]
        public HttpResponseMessage GetCategories()
        {
            var result = _db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories/{categoryId}/products")]
        public HttpResponseMessage GetProductsByCategories(int categoryId)
        {
            var result = _db.Products.Where(x => x.CategoryId == categoryId).Include("Category");
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [ResponseType(typeof (Product))]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _db.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProduct(Product product)
        {
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, product);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("products")]
        public HttpResponseMessage PutProduct(Product product)
        {
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPatch]
        [Route("products")]
        public HttpResponseMessage PatchProduct(Product product)
        {
            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("products/{productId}")]
        public HttpResponseMessage DeleteProduct(int productId)
        {
            if (productId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                var product = _db.Products.Find(productId);
                if (product != null)
                {
                    _db.Products.Remove(product);
                    _db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {

                _log.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
