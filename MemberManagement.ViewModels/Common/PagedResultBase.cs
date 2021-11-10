using System;

namespace MemberManagement.ViewModels.Common
{
    public class PagedResultBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        private int pageCount1;

        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecords / PageSize;
                pageCount1 = (int)Math.Ceiling(pageCount);
                return pageCount1;
            }
            set
            {
               this.pageCount1 = value;
            }
        }
    }
}