using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.MemberViewModels
{
    public class MemberEditRequest
    {
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public DateTime JoinDate { get; set; }
        public string Idcard { get; set; }
        public string Notes { get; set; }
    }
}
