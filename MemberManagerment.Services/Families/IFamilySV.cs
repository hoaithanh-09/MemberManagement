using MemberManagement.Data.Entities;
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
        Task<int> Create(FamilyCreatRequest request);
        Task<int> Delete(int id);
        Task<FamilyVM> GetById(int id);
        Task<PagedResult<FamilyVM>> GetPagedResult(GetFamilyPagingRequest request);
        Task<Family> Update(int id, FamilyEditRequest request);
    }
}
