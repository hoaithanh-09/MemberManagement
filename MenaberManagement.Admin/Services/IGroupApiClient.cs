using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.GroupViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
   public interface IGroupApiClient
    {
        Task<List<GroupVM>> GetAll( );
        Task<PagedResult<GroupVM>> GetFamilyPaging(GetGroupPagingRequest request);

        Task<bool> Create(GroupCreateRequest request);

        Task<bool> Update(int id, GroupEditRequest request);
        Task<GroupVM> GetById(int id);
        Task<bool> Delete(int id);
    }
}
