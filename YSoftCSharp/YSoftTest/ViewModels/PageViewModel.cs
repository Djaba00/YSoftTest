using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YSoftTest.ViewModels
{
    public class PageViewModel
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages
        { 
            get 
            { 
                return (int)Math.Ceiling((double)TotalItems / PageSize); 
            } 
        }

        public PageViewModel(int itemsCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = itemsCount;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}