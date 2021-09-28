using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
   public interface IMemberApiClient
    {
        Task<PagedResult<MemberVM>> GetFamilyPaging(MemberPaingRequest request);

        Task<ApiResult<string>> Create(MemberCreatRequest request);

        Task<bool> Update(int id, MemberEditRequest request);
        Task<MemberVM> GetById(int id);
        Task<bool> Delete(int id);
    }
}
