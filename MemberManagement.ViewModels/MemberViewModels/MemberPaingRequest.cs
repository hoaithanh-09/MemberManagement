using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.MemberViewModels
{
    public class MemberPaingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        public string GroupId { get; set; }
        public string FamilyId { get; set; }
    }
}
