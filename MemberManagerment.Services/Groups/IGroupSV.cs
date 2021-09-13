using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.GroupViewModels;
using MemberManagerment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Groups
{
    public interface IGroupSV
    {
        Task<List<GroupVM>> GetAll();
        Task<Group> Update(string id, GroupEditRequest request);
        Task<string> Create(GroupCreateRequest request);
        Task<string> Delete(string id);
        Task<GroupVM> GetById(string id);

        Task<PagedResult<GroupVM>> GetPagedResult(GetGroupPagingRequest request);
    }
}
