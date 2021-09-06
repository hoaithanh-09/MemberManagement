using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagerment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Addresses
{
     public interface IAddressSV
    {
        Task<string> Create(AddressCreatRequest request);
        Task<int> Delete(string id);
        Task<AddressVM> GetById(string id);
        Task<PagedResult<AddressVM>> GetPagedResult(GetAddressPagingRequest request);
        Task<int> Update(string id,AddressEditRequest request);
        Task<Address> Update2(string id, AddressEditRequest request);
    }
}
