using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.UploadViewModels
{
    public class UploadViewModel
    {
        [Required]
        public int RoomId { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
