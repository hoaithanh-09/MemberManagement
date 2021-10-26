using MemberManagement.ViewModels.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.ViewModels.TopicViewModels
{
    public class GetTopicPagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
    } 
}
