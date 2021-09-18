using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.MemberViewModels
{
    public class MemberPaingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        public int GroupId { get; set; }
        public int FamilyId { get; set; }
    }
}
