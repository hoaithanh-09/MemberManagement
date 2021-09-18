using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.Common;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Addresses
{
     public interface IAddressSV
    {
        Task<int> Create(AddressCreatRequest request);
        Task<int> Delete(int id);
        Task<AddressVM> GetById(int id);
        Task<PagedResult<AddressVM>> GetPagedResult(GetAddressPagingRequest request);
        Task<Address> Update(int id, AddressEditRequest request);
    }
}
