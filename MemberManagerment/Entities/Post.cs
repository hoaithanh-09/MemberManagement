using System;
using System.Collections.Generic;



namespace MemberManagement.Data.Entities
{
    public partial class Post
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Text { get; set; }

        public virtual AppUser Author { get; set; }
    }
}
