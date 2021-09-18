using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.GroupViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Groups
{
    public interface IGroupSV
    {
        Task<List<GroupVM>> GetAll();
        Task<Group> Update(int id, GroupEditRequest request);
        Task<int> Create(GroupCreateRequest request);
        Task<int> Delete(int id);
        Task<GroupVM> GetById(int id);

        Task<PagedResult<GroupVM>> GetPagedResult(GetGroupPagingRequest request);
    }
}
