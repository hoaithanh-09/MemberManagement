using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ActivityViewModels
{
    public class GetActivityPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
