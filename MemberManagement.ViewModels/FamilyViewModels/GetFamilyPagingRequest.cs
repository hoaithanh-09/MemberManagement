using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FamilyViewModels
{
    public class GetFamilyPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
