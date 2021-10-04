using System;
using System.Collections.Generic;



namespace MemberManagement.Data.Entities
{
    public partial class Post
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Titel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Text { get; set; }

        public virtual AppUser Author { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
