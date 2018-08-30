using System;
using System.Net;

namespace SchoolExpress.WebService.Utils
{
    public class LogMetadata
    {
        public string Method { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Scheme { get; set; }
        public string RequestContentType { get; set; }
        public string RequestUri { get; set; }     
        public DateTime? RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; }
        public string ResponseUri { get; set; }
        public DateTime? ResponseTimestamp { get; set; }
    }
}