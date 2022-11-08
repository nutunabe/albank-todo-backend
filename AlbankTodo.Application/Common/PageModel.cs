using System;
using System.Collections.Generic;

namespace AlbankTodo.Application.Common
{
    public class PageModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }


        public PageModel(IEnumerable<T> items, int pageNumber, int pageSize, int count)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
