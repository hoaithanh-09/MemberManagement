using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.User
{
    public interface IUserSV
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<PagedResult<UserVM>> GetUserPaging(GetUserPagingRequest request);

        Task<ApiResult<bool>> Update(int id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserVM>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<UserVM>> GetByGmail(string id);

        Task<ApiResult<bool>> Delete(int id);


    }
}
