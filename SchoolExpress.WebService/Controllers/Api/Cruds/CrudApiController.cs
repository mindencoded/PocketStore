using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Cruds
{
    public abstract class CrudApiController<T> : BaseApiController where T : class
    {
        protected CrudApiController(IUow uow) : base(uow)
        {
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}")]
        [HttpGet]
        public virtual async Task<QueryResponse> Get(int page, int pageSize, string orderBy)
        {
            return await CreateQuery(page, pageSize, orderBy, null, null);
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}/{where}")]
        [HttpGet]
        public virtual async Task<QueryResponse> Get(int page, int pageSize, string orderBy, string where)
        {
            return await CreateQuery(page, pageSize, orderBy, where, null);
        }

        [Route("{page:int}/{pageSize:int}/{orderBy}/{where}/{select}")]
        [HttpGet]
        public virtual async Task<QueryResponse> Get(int page, int pageSize, string orderBy, string where,
            string select)
        {
            return await CreateQuery(page, pageSize, orderBy, where, select);
        }

        private async Task<QueryResponse> CreateQuery(int page, int pageSize, string orderBy, string where,
            string select)
        {
            if (pageSize < page)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize must be greater than page");
            }

            IList<string> orderByList = new List<string>();
            string[] orderByArray = orderBy.Split(',');
            foreach (string orderByItem in orderByArray)
            {
                if (!string.IsNullOrEmpty(orderByItem))
                {
                    if (!orderByItem.EndsWith(" ASC", StringComparison.OrdinalIgnoreCase) &&
                        !orderByItem.EndsWith(" DESC", StringComparison.OrdinalIgnoreCase))
                    {
                        orderByList.Add(orderByItem + " ASC");
                    }
                    else
                    {
                        orderByList.Add(orderByItem);
                    }
                }
            }

            IQueryable<T> query = Uow.GetRepositoryForEntityType<T>().GetAll();
            if (!string.IsNullOrEmpty(where))
            {
                int countParam = 0;
                IList<object> parameters = new List<object>();
                IList<string> andExpressionsList = new List<string>();

                string[] andExpressions = Regex.Split(where, "AND", RegexOptions.IgnoreCase);
                foreach (string andExpression in andExpressions)
                {
                    string[] orExpressions = Regex.Split(andExpression, "OR", RegexOptions.IgnoreCase);
                    if (orExpressions.Length > 1)
                    {
                        IList<string> orExpressionsList = new List<string>();
                        foreach (string orExpression in orExpressions)
                        {
                            object value;
                            string expression = BuildExpression(orExpression, countParam, out value);
                            if (expression != null)
                            {
                                orExpressionsList.Add(expression);
                                parameters.Add(value);
                                countParam++;
                            }
                        }

                        andExpressionsList.Add(string.Join(" OR ", orExpressionsList.ToArray()));
                    }
                    else
                    {
                        object value;
                        string expression = BuildExpression(andExpression, countParam, out value);
                        if (expression != null)
                        {
                            andExpressionsList.Add(expression);
                            parameters.Add(value);
                            countParam++;
                        }
                    }
                }

                query = query.Where(string.Join(" AND ", andExpressionsList.ToArray()), parameters.ToArray());
            }

            int total = await query.CountAsync();
            if (page == 0 && pageSize == 0)
            {
                query = query.OrderBy(string.Join(",", orderByList.ToArray()));
            }
            else
            {
                query = query.OrderBy(string.Join(",", orderByList.ToArray())).Skip((page - 1) * pageSize)
                    .Take(pageSize);
            }

            IList<dynamic> result;
            if (!string.IsNullOrEmpty(select))
            {
                result = await query.Select(new StringBuilder().Append("new (").Append(select).Append(")").ToString())
                    .ToListAsync();
            }
            else
            {
                result = await query.ToListAsync<dynamic>();
            }

            int count = result.Count();
            int pages = CalculateTotalPages(total, pageSize);
            return new QueryResponse
            {
                Value = result,
                Count = count,
                Total = total,
                Pages = pages,
                Page = page,
                PageSize = pageSize
            };
        }

        public string BuildExpression(string expression, int count, out object value)
        {
            value = null;
            foreach (string symbol in RelationalOperatorExtension.Symbols)
            {
                string[] parts = expression.Split(new[] {symbol}, StringSplitOptions.None).Select(p => p.Trim())
                    .ToArray();
                if (parts.Length > 1)
                {
                    string property = parts[0];
                    string openParenthesis = "";
                    while (property.StartsWith("("))
                    {
                        property = property.Substring(1);
                        openParenthesis += "(";
                    }

                    string strValue = parts[1];
                    string closeParenthesis = "";
                    while (strValue.EndsWith(")"))
                    {
                        strValue = strValue.Remove(strValue.Length - 1);
                        closeParenthesis += ")";
                    }

                    RelationalOperator relationalOperator = RelationalOperatorExtension.GetOperator(symbol);
                    if (relationalOperator == RelationalOperator.Contains)
                    {
                        string[] cleanValues = Regex.Replace(strValue, @"^(\[|\(){1}(.*?)(\]|\)){1}$", "$2")
                            .Split(',').Select(p => p.Trim('\'', ' ')).ToArray();

                        IList listValues;
                        PropertyInfo propertyInfo = typeof(T).GetProperty(property);
                        if (propertyInfo != null)
                        {
                            listValues =
                                (IList) Activator.CreateInstance(
                                    typeof(List<>).MakeGenericType(propertyInfo.PropertyType));
                            foreach (string cleanValue in cleanValues)
                            {
                                listValues.Add(Convert.ChangeType(cleanValue, propertyInfo.PropertyType));
                            }

                            value = listValues;
                        }
                        else
                        {
                            listValues = new List<string>();
                            foreach (string cleanValue in cleanValues)
                            {
                                listValues.Add(cleanValue);
                            }

                            value = listValues;
                        }

                        return new StringBuilder().Append(openParenthesis).Append("@").Append(count)
                            .Append(".Contains(outerIt.").Append(property).Append(")").Append(closeParenthesis)
                            .ToString();

                    }
                    else
                    {
                        string cleanValue = strValue.Trim('\'', ' ');
                        PropertyInfo propertyInfo = typeof(T).GetProperty(property);
                        if (propertyInfo != null)
                        {
                            value = Convert.ChangeType(cleanValue, propertyInfo.PropertyType);
                        }
                        else
                        {
                            value = cleanValue;
                        }

                        if (relationalOperator == RelationalOperator.Like ||
                            relationalOperator == RelationalOperator.StartsWith)
                        {
                            string method = "Contains";
                            if (relationalOperator == RelationalOperator.StartsWith)
                            {
                                method = "StartsWith";
                            }

                            return new StringBuilder().Append(openParenthesis).Append("it.").Append(property)
                                .Append(".").Append(method).Append("(@").Append(count).Append(")")
                                .Append(closeParenthesis)
                                .ToString();
                        }

                        return new StringBuilder().Append(openParenthesis).Append(property).Append(" ")
                            .Append(symbol).Append(" ").Append("@" + count).Append(closeParenthesis).ToString();
                    }
                }
            }

            return null;
        }

        [Route("{id}")]
        [HttpGet]
        public virtual async Task<HttpResponseMessage> Get(object id)
        {
            T entity = await Uow.GetRepositoryForEntityType<T>().GetByIdAsync(id);
            if (entity != null)
            {
                return new HttpResponseMessage
                {
                    Content = new ObjectContent<T>(entity, new JsonMediaTypeFormatter(),
                        new MediaTypeHeaderValue("application/json"))
                };
            }

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
            if (entity is IEntity)
            {
                response.Headers.Location =
                    new Uri(Request.RequestUri.AbsoluteUri +
                            (((IEntity) entity).GetId() != null
                                ? "/" + string.Join("/", ((IEntity) entity).GetId())
                                : ""));
            }

            return response;
        }

        [Route("")]
        [HttpPatch]
        public virtual async Task<HttpResponseMessage> Patch([FromBody] string json)
        {
            ExpandoObject expandoObject = JsonConvert.DeserializeObject<ExpandoObject>(json);
            Uow.ValidateOnSaveEnabled(false);
            Uow.GetRepositoryForEntityType<T>().Update(expandoObject);
            await Uow.CommitAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public virtual async Task<HttpResponseMessage> Delete(object id)
        {
            Uow.GetRepositoryForEntityType<T>().Delete(id);
            await Uow.CommitAsync();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        private int CalculateTotalPages(int totalItems, int itemsPerPage)
        {
            int totalPages = totalItems / itemsPerPage;

            if (totalItems % itemsPerPage != 0)
            {
                totalPages++; // Last page with only 1 item left
            }

            return totalPages;
        }
    }
}