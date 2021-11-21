using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FundGroupVIewModels;
using MemberManagement.ViewModels.FundMemberViewModels;
using MemberManagement.ViewModels.FundViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
    public interface IFundApi
    {
        Task<PagedResult<FundVM>> GetFundPaging(GetFundPagingRequest request);

        Task<ApiResult<string>> Create(FundCreateRequest request);

        Task<bool> Update(int id, FundEditRequest request);
        Task<FundVM> GetById(int id);
        Task<bool> Delete(int id);
        Task<PagedResult<ListAction>> ListAction(int fundId, GetFundPagingRequest request);
        Task<PagedResult<ListMember>> ListMembers(int fundId, GetFundPagingRequest request);
        Task<bool> AddMember(int fundId, FundMemberCreateRequest request);
        Task<bool> AddAction(int fundId, FundGroupCreateRequest request);
    }
}
