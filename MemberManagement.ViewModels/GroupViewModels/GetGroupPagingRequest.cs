using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.GroupViewModels
{
   public class GetGroupPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
