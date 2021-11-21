using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FundGroupVIewModels;
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
        Task<bool> AddAction(int fundId, FundGroupCreateRequest request);
        Task<PagedResult<ListAction>> ListAction(int fundId, GetFundPagingRequest request);
        Task<bool> RomoveAction(int fundId, int idMember);
        Task<PagedResult<ListMember>> ListMembers(int FundId, GetFundPagingRequest request);
        Task<bool> AddMember(int fundId, FundMemberCreateRequest request);
        Task<bool> RomoveAMember(int fundId, int idMember);
    }
}
