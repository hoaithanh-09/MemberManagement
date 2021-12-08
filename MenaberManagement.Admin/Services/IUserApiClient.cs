using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.RoleAppVM;
using MemberManagement.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
   public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserVM>>> GetUserPaging(GetUserPagingRequest request);

        Task<ApiResult<string>> RegisterUser(RegisterRequest request);

        Task<ApiResult<bool>> Update(int id, UserUpdateRequest request);
        Task<ApiResult<UserVM>> GetById(int id);
        Task<UserVM> GetByName(string name);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> RoleAssign(int id, RoleAssignRequest request);

    }
}
