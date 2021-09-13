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
        Task<string> Authencate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);

        Task<PagedResult<UserVM>> GetUserPaging(GetUserPagingRequest request);

        Task<bool> Update(string id, UserUpdateRequest request);

        Task<PagedResult<UserVM>> GetUsersPaging(GetUserPagingRequest request);

        Task<UserVM> GetById(string id);

        Task<bool> Delete(string id);

    }
}
