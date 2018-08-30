using System;
using System.Linq;

namespace SchoolExpress.WebService.Utils
{
    public static class QueryableExtension
    {
        public static IQueryable<T> PagedIndex<T>(this IQueryable<T> query, Pagination pagination, int pageIndex) //where T : Entity
        {
            if (pageIndex < pagination.MinPage || pageIndex > pagination.MaxPage)
            {
                throw new ArgumentOutOfRangeException(null, $"*** Page index must >= {pagination.MinPage} and =< {pagination.MaxPage}! ***");
            }

            // Return IQueryable<T> to enable chained-methods calls
            return query
                //.OrderBy(T => T.EntityProperty) [NOT this extension responsibility]
                .Skip(GetSkip(pageIndex, pagination.PageSize))
                .Take(pagination.PageSize);
        }

        private static int GetSkip(int pageIndex, int take)
        {
            return (pageIndex - 1) * take;
        }
    }
    
    public class Pagination
    {
        public int TotalItems { get; } // Equal to PageSize * MaxPage
        public int PageSize { get; } // Number of items per page
        public int MinPage { get; } = 1; // Page index starting from MinPage to MaxPage
        public int MaxPage { get; } //Total pages

        public Pagination(int totalItems, int itemsPerPage)
        {
            if (itemsPerPage < MinPage)
            {
                throw new ArgumentOutOfRangeException (null, $"*** Number of items per page must > 0! ***");
            }

            TotalItems = totalItems;
            PageSize = itemsPerPage;
            MaxPage = CalculateTotalPages(totalItems, itemsPerPage);
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