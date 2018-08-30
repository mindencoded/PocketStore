using System.Collections.Generic;

namespace SchoolExpress.WebService.Utils
{
    public class QueryResponse
    {
        public IEnumerable<dynamic> Value { get; set; }
        
        public int Count { get; set; }
        
        public int Total { get; set; }
    }
}