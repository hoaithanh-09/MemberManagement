﻿using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
  public  interface IAddressApiClient
    {
        Task<PagedResult<AddressVM>> GetFamilyPaging(GetAddressPagingRequest request);

        Task<bool> Create(AddressCreatRequest request);

        Task<bool> Update(int id, AddressEditRequest request);
        Task<AddressVM> GetById(int id);
        Task<bool> Delete(int id);
    }
}
