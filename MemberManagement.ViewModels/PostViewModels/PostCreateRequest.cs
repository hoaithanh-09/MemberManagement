using MemberManagement.ViewModels.ImageViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.PostViewModels
{
    public class PostCreateRequest
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now.Date;
        [Display(Name = "Ngày chỉnh sửa")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Hình ảnh")]
        
        public int? AuthorId { get; set; }

        public IFormFile? ThumbnailImage { get; set; }
    }
}
