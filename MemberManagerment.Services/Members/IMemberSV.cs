using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.MemberViewModels;
using MemberManagerment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Members
{
   public interface IMemberSV
    {
        Task<PagedResult<MemberVM>> GetAllPaging(MemberPaingRequest request);
        Task<string> Create(MemberCreatRequest request);
        Task<MemberVM> GetById(string id);
        Task<Member> Update(string id, MemberEditRequest request);
    }
}
