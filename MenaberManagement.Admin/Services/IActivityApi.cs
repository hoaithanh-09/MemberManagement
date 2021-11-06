using MemberManagement.ViewModels.ActivityViewModels;
using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
    public interface IActivityApi
    {
        Task<List<ActivityVM>> GetAll();
        Task<PagedResult<ActivityVM>> GetActivityPaging(GetActivityPagingRequest request);

        Task<ApiResult<string>> Create(ActivityCreateRequest request);

        Task<bool> Update(int id, ActivityEditRequest request);
        Task<ActivityVM> GetById(int id);
        Task<bool> Delete(int id);
    }
}
