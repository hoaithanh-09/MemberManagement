using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.ActivityMemberViewModels
{
    public class ActivityMemberCreateRequest
    {
        public int MemberId { get; set; }
        public int ActivityId { get; set; }
    }
}
