using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Data.Entities
{
    public class PostImage
    {
        public int PostId { get; set; }
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Post Post { get; set; }
    }
}
