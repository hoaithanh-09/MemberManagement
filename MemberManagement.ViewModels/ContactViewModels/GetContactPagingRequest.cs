using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ContactViewModels
{
    public class GetContactPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
