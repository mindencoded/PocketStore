using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SchoolExpress.WebService.Utils
{
    public class HttpActionResult : IHttpActionResult
    {
        public HttpActionResult(string reasonPhrase, HttpStatusCode httpStatusCode, HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
            HttpStatusCode = httpStatusCode;
        }

        public HttpActionResult(HttpStatusCode httpStatusCode, HttpRequestMessage request)
        {
            ReasonPhrase = null;
            Request = request;
            HttpStatusCode = httpStatusCode;
        }

        public string ReasonPhrase { get; }

        public HttpRequestMessage Request { get; }

        public HttpStatusCode HttpStatusCode { get; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode)
            {
                RequestMessage = Request
            };
            if (ReasonPhrase != null)
            {
                response.ReasonPhrase = ReasonPhrase;
            }

            return response;
        }
    }
}