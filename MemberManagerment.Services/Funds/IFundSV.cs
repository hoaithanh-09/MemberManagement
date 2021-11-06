using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FundMemberViewModels;
using MemberManagement.ViewModels.FundViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Funds
{
    public interface IFundSV
    {
        Task<List<FundVM>> GetAll();
        Task<ApiResult<string>> Create(FundCreateRequest request);
        Task<int> Delete(int id);
        Task<FundVM> GetById(int id);
        Task<Fund> Update(int id, FundEditRequest request);
        Task<PagedResult<FundVM>> GetPagedResult(GetFundPagingRequest request);
        Task<int> AddMember(int fundId, FundMemberCreateRequest request);
    }
}
