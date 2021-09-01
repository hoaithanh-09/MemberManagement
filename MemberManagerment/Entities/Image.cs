using System;
using System.Collections.Generic;

#nullable disable

namespace MemberManagerment.Data.Entities
{
    public partial class Image
    {
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DateCreated { get; set; }
        public long? FileSize { get; set; }

        public virtual Member Member { get; set; }
    }
}
