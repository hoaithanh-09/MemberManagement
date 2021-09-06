using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FamilyViewModels;
using MemberManagerment.ViewModels.FamilyViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Families
{
    public interface IFamilySV
    {
        Task<List<FamilyVM>> getAll();
        Task<string> Create(FamilyCreatRequest request);
        Task<int> Delete(string id);
        Task<FamilyVM> GetById(string id);
        Task<PagedResult<FamilyVM>> GetPagedResult(GetFamilyPagingRequest request);
    }
}
