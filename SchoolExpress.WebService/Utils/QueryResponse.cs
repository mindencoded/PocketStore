using System.Collections.Generic;

namespace SchoolExpress.WebService.Utils
{
    public class QueryResponse<T>
    {
        public IEnumerable<T> Value { get; set; }
        
        public int Total { get; set; }
        
        public int Count { get; set; }
    }
}