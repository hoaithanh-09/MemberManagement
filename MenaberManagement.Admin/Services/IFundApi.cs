using MemberManagement.ViewModels.Common;
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
        Task<PagedResult<FundAction>> ListAction(int fundId, GetFundPagingRequest request);
    }
}
