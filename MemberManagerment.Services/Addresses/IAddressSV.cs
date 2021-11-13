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
        Task<List<AddressVM>> GetAll();
        Task<int> Create(AddressCreatRequest request);
        Task<int> Delete(int id);
        Task<AddressVM> GetById(int id);
        Task<PagedResult<AddressVM>> GetPagedResult(GetAddressPagingRequest request);
        Task<Address> Update(int id, AddressEditRequest request);
        Task<List<ProvinceVM>> LoadProvince();

        Task<List<DistrictVM>> LoadDistrict(int id);

        Task<List<WardVM>> LoadWard(int id);
        Task<string> Test();
    }
}
