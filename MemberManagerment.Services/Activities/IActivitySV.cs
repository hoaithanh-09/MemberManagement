using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.ActivityMemberViewModels;
using MemberManagement.ViewModels.ActivityViewModels;
using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Activities
{
    public interface IActivitySV
    {
        Task<List<ActivityVM>> GetAll();
        Task<ApiResult<string>> Create(ActivityCreateRequest request);
        Task<int> Delete(int id);
        Task<ActivityVM> GetById(int id);
        Task<Activity> Update(int id, ActivityEditRequest request);
        Task<PagedResult<ActivityVM>> GetPagedResult(GetActivityPagingRequest request);
        Task<int> AddMember(int activityId, ActivityMemberCreateRequest request);


    }
}
