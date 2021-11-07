using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Data.Entities
{
  public class FundGroup
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.Date;
        public string Description { get; set; }
        public bool Finish { get; set; } = true;

        public int FundId { get; set; }
        public int GroupId { get; set; }

        public virtual Fund Fund { get; set; }
        public virtual Group Group { get; set; }
    }
}
