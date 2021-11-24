using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.ImageViewModels
{
    public class ImageCreateRequest
    {
        [Display(Name = "Mã hình ảnh")]
        public int Id { get; set; }
        [Display(Name = "Đường dẫn")]
        public string ImagePath { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? DateCreated { get; set; }
        [Display(Name = "Kích cỡ")]
        public long? FileSize { get; set; }
    }
}
