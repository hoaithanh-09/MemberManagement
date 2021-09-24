using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FamilyViewModels;
using MemberManagerment.ViewModels.FamilyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Services
{
    public class FamilyApiClient : IFamilyApiClient
    {
        public Task<bool> Create(FamilyCreatRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FamilyVM> GetById(int id)
        {
            throw new NotImplementedException();
        }
        
        public Task<PagedResult<FamilyVM>> GetUserPaging(GetFamilyPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, FamilyEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
