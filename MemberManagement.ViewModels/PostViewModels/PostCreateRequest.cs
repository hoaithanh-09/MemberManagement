using MemberManagement.ViewModels.ImageViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.PostViewModels
{
    public class PostCreateRequest
    {
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now.Date;
        public DateTime? ModifiedDate { get; set; }
        public int? AuthorId { get; set; }
        public string Content { get; set; }

        public IFormFile ThumbnailImage { get; set; }
    }
}
