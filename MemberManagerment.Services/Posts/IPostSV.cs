
using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.ImageInPostViewModels;
using MemberManagement.ViewModels.PostViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemberManagement.Services.Posts
{
    public interface IPostSV
    {
        //Post
        Task<List<PostVM>> GetAll();
        Task<ApiResult<string>> Create(PostCreateRequest request);
        Task<string> Delete(int id);
        Task<PostVM> GetById(int id);
        Task<Post> Update(int id, PostEditRequest request);
        Task<PagedResult<PostVM>> GetPagedResult(GetPostPagingRequest request);
        Task<int> AddImage(int postId, ImageInPostCreateRequest request);


    }
}
