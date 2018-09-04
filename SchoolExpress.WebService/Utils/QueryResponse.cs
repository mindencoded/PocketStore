using System.Collections.Generic;

namespace SchoolExpress.WebService.Utils
{
    public class QueryResponse
    {
        public IEnumerable<dynamic> Value { get; set; }
        
        public int Count { get; set; }
        
        public int Total { get; set; }

        public int Pages { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}