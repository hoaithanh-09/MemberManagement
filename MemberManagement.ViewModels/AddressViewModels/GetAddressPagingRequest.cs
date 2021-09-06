using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.AddressViewModels
{
    public class GetAddressPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
