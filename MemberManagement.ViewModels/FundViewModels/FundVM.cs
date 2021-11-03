using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FundViewModels
{
    public class FundVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? TotalFund { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Description { get; set; }

    }
}
