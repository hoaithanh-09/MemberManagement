using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FundViewModels
{
    public class GetFundPagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
