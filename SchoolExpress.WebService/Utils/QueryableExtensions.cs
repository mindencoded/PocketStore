using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolExpress.WebService.Utils
{
    public static class QueryableExtensions
    {
        public static async Task<dynamic> CreateQuery<T>(this IQueryable<T> query, int page, int pageSize,
            string orderBy, string where,
            string select) where T : class
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page), "page must be greater than 0.");
            }
            /*if (pageSize < page)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize must be greater than page.");
            }*/

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
                            string expression = BuildExpression<T>(orExpression, countParam, out value);
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
                        string expression = BuildExpression<T>(andExpression, countParam, out value);
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


            query = query.OrderBy(string.Join(",", orderByList.ToArray())).Skip((page - 1) * pageSize).Take(pageSize);


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

            int count = result.Count;
            int pages = CalculateTotalPages(total, pageSize);
            dynamic expandoObject = new ExpandoObject();
            expandoObject.Value = result;
            expandoObject.Count = count;
            expandoObject.Total = total;
            expandoObject.Pages = pages;
            expandoObject.Page = page;
            expandoObject.PageSize = pageSize;
            return expandoObject;
        }

        private static string BuildExpression<T>(string expression, int count, out object value) where T : class
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


        private static int CalculateTotalPages(int totalItems, int itemsPerPage)
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