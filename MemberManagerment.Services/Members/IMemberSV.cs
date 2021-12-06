using ClosedXML.Excel;
using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.AddressMemberViewModels;
﻿using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.ContractMemberViewModels;
using MemberManagement.ViewModels.MemberViewModels;
using MemberManagement.ViewModels.RoleMemberViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Members
{
   public interface IMemberSV
    {
        Task<List<MemberVM>> GetAll();
        Task<PagedResult<MemberVM>> GetAllPaging(MemberPaingRequest request);
        Task<ApiResult<string>> Create(MemberCreatRequest request);
        Task<int> AddAddress(int member, AddressMemberCreateRequest request);
        Task<MemberVM> GetById(int id);
        Task<Member> Update(int id, MemberEditRequest request);
        //Task<int> AddContact(int memberId, ContactMemberCreateRequest request);
        Task<int> AddRole(int memberId, RoleMemberCreateRequest request);

        Task<string> Delete(int id);
        Task<XLWorkbook> ExportMember();
    }
} 
