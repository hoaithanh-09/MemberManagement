using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.UserViewModels
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
