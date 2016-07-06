using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCModuleStarter.Helpers
{ 

    public class PaginatedList<T> : List<T> {

        public int PageIndex  { get; private set; }
        public int PageSize   { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(IQueryable<T> source, int pageIndex, Func<T, IComparable> orderBy, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int) Math.Ceiling(TotalCount / (double)PageSize);
            this.AddRange(source.OrderBy(orderBy)
                .Skip(pageIndex * pageSize)
                .Take(pageSize));
        }

        public bool HasPreviousPage {
            get {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage {
            get {
                return (PageIndex+1 < TotalPages);
            }
        }
    }
}
