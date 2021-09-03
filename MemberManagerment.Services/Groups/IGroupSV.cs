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

        Task<string> Create(GroupCreateRequest request);
        Task<string> Delete(string id);
        Task<GroupVM> GetById(string id);
    }
}
