using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.RoleViewModels
{
    public class GetRolePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
