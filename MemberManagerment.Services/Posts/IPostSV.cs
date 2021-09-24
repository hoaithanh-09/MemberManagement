using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Posts
{
    public interface IPostSV
    {
        Task<List<PostVM>> getAll();
        Task<int> Create(PostCreatRequest request);
        Task<int> Delete(int id);
        Task<PostVM> GetById(int id);
        Task<PagedResult<PostVM>> GetPagedResult(GetPostPagingRequest request);
        Task<Post> Update(int id, PostEditRequest request);
    }
}
