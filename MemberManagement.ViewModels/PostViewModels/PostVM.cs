
using MemberManagement.ViewModels.ImageInPostViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.PostViewModels
{
    public class PostVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ModifiedDate { get; set; }
        public int? AuthorId { get; set; }
        public string Content { get; set; }

        public string PathFile { get; set; }

        public ImageInPostVM ImageInPosts { get; set; }

        

    }
}
