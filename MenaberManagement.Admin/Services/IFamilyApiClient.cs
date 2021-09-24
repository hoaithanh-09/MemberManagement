using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FamilyViewModels;
using MemberManagerment.ViewModels.FamilyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
    public interface IFamilyApiClient
    {
        Task<PagedResult<FamilyVM>> GetUserPaging(GetFamilyPagingRequest request);

        Task<bool> Create(FamilyCreatRequest request);

        Task<bool> Update(int id, FamilyEditRequest request);
        Task<FamilyVM> GetById(int id);
        Task<bool> Delete(int id);
    }
}
