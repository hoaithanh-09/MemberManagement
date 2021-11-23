using MemberManagement.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.TopicViewModels
{
    public class TopicCreateRequest
    {
        [Display(Name = "Mã chủ đề")]
        public int Id { get; set; }
        [Display(Name = "Chủ đề")]
        public string Title { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Mã bài viết")]
        public int PostId { get; set; }
        public List<PostVM> Post { get; set; }
    }
}
