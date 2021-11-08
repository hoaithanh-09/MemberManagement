using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FundGroupVIewModels
{
    public class FundGroupCreateRequest
    {
        public int FundId { get; set; }
        public int GroupId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;
        public string Description { get; set; }
        public bool Finish { get; set; } = true;

    }
}
