using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }   
}
