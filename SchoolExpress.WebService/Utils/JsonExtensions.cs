
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SchoolExpress.WebService.Utils
{
    public static class JsonExtensions
    {
        public static dynamic ToDynamic(this JToken token)
        {
            if (token == null)
                return null;
            if (token is JObject)
                return token.ToObject<ExpandoObject>();
            if (token is JArray)
                return token.ToObject<List<ExpandoObject>>().Cast<dynamic>().ToList();
            if (token is JValue)
                return ((JValue)token).Value;
            throw new JsonSerializationException(string.Format("Token type not implemented: {0}", token));
        }
    }
}
