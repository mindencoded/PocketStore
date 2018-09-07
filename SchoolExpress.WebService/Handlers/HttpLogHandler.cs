using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Handlers
{
    
    public class HttpLogHandler: DelegatingHandler
    {
        private static readonly ILog Logger = LogManager.GetLogger("customTraceSource");


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LogMetadata logMetadata = BuildRequestMetadata(request);
            Logger.TraceFormat("Initiated request: \"{0}\" {1}", logMetadata.Method, logMetadata.RequestUri);
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            logMetadata = BuildResponseMetadata(logMetadata, response);
            Logger.TraceFormat("Completed request: {0} with status {1} {2}", logMetadata.ResponseUri, logMetadata.Scheme, (int) logMetadata.StatusCode);
            return response;
        }
        
        private LogMetadata BuildRequestMetadata(HttpRequestMessage request)
        {
            LogMetadata logMetadata = new LogMetadata
            {
                Method = request.Method.Method,
                RequestTimestamp = DateTime.Now,
                RequestUri = request.RequestUri.ToString(),
            
            };
            MediaTypeHeaderValue contentType = request.Content.Headers.ContentType;
            if (contentType != null)
            {
                logMetadata.RequestContentType = contentType.MediaType;
            }

            return logMetadata;
        }
        
        private LogMetadata BuildResponseMetadata(LogMetadata logMetadata, HttpResponseMessage response)
        {
            logMetadata.StatusCode = response.StatusCode;
            logMetadata.ResponseTimestamp = DateTime.Now;
            logMetadata.ResponseUri = response.RequestMessage.RequestUri.ToString();
            logMetadata.Scheme = response.RequestMessage.RequestUri.Scheme.ToUpper();
            MediaTypeHeaderValue contentType = response.Content.Headers.ContentType;
            if (contentType != null)
            {
                logMetadata.ResponseContentType = contentType.MediaType;
            }            
            return logMetadata;
        }     
    }
}