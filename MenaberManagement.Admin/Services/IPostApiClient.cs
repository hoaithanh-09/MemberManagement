using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MenaberManagement.Admin.Services
{
    public interface IPostApiClient
    {
        Task<PagedResult<PostVM>> GetPostPaging(GetPostPagingRequest request);
        Task<PostVM> GetById(int id);
    }
}
