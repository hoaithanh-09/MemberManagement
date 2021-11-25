using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.ViewModels.MessageViewModels
{
    public class MessageViewModel
    {
        [Required]
        public string Content { get; set; }
        public string Timestamp { get; set; }
        public string From { get; set; }
        [Required]
        public string Room { get; set; }
        public string Avatar { get; set; }
    }
}
