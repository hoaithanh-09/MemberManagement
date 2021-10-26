using MemberManagement.ViewModels.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.ImageViewModels
{
    public class GetImagePagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
