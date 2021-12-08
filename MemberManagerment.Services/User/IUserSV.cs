using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.RoleAppVM;
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

        Task<ApiResult<PagedResult<UserVM>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<bool>> Update(int id, UserUpdateRequest request);


        Task<ApiResult<UserVM>> GetById(int id);

        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> RoleAssign(int id, RoleAssignRequest request);
        Task<UserVM> GetByName(string name);
    }
}
