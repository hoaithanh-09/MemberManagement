using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.ViewModels.FGViewModels
{
    public class FundGoupCreateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;
        public string Description { get; set; }
        public bool Finish { get; set; } = true;

        public int FundId { get; set; }
        public int GroupId { get; set; }
    } 
    public class FundGoupVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;
        public string Description { get; set; }
        public bool Finish { get; set; } = true;

        public int FundId { get; set; }
        public int GroupId { get; set; }
    } 
    public class FundGoupEditRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;
        public string Description { get; set; }
        public bool Finish { get; set; } = true;

        public int FundId { get; set; }
        public int GroupId { get; set; }
    } 
}
