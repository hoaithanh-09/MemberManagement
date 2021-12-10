using ManaberManagement.Utilities;
using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FGViewModels;
using MemberManagement.ViewModels.FundViewModels;
using MemberManagerment.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.FundGroupSServices
{
    public interface IFundMemberService
    {

        Task<ApiResult<string>> Create(FundMemberCreateRequest request);
        Task<string> Delete(int id);
        Task<FundMemberVM> GetById(int id);
        Task<FundMember> Update(int id, FundMemberEditRequest request);

        Task<PagedResult<FundMemberVM>> GetPaged(int FundId, GetFundPagingRequest request);
    }
    public class FundMemberService : IFundMemberService
    {
        private readonly MemberManagementContext _context;

        public FundMemberService(MemberManagementContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<FundMemberVM>> GetPaged(int FundId, GetFundPagingRequest request)
        {
            var fun = await _context.FundMembers.AsQueryable().Where(x => x.FundId == FundId).Select(y => new FundMemberVM()
            {
                Id = y.Id,
                CreateDate = y.CreateDate,
                FundId = y.FundId,
                MemberId = y.MemberId,
                Status = y.Status,
                Total = y.Total,
            }).ToListAsync();
            var pagedResult = new PagedResult<FundMemberVM>()
            {
                Items = fun,
                PageCount = fun.Count,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize

            };
            return pagedResult;
        }
        public async Task<ApiResult<string>> Create(FundMemberCreateRequest request)
        {
            var funmember = new FundMember()
            {
                Id = request.Id,
                MemberId = request.MemberId,
                Status = request.Status,
                CreateDate = request.CreateDate,
                FundId = request.FundId,
                Total=request.Total,
            };
            _context.FundMembers.Add(funmember);
            var a = await _context.SaveChangesAsync();
            if (a > 0)
            {
                return new ApiSuccessResult<string>("Tạo thành công");

            }
            return new ApiErrorResult<string>("Tạo mới thất bại");
        }

       

        public async Task<string> Delete(int id)
        {
            var fundMembers = await _context.FundMembers.FindAsync(id);
            _context.FundMembers.Remove(fundMembers);
            int a = await _context.SaveChangesAsync();
            if(a>0)
                return "Xóa thành công";
            return "Xóa thất bại";
        }

        public async Task<FundMemberVM> GetById(int id)
        {
           var fundmember = await _context.FundMembers.FindAsync(id);
            if (fundmember == null)
            {
                throw new MemberManagementException("Không tìm thấy thành viên đóng quỹ");
            }
            return new FundMemberVM() {
                Id = fundmember.Id,
                CreateDate= fundmember.CreateDate,
                FundId= fundmember.FundId,
                MemberId= fundmember.MemberId,
                Status = fundmember.Status,
                Total = fundmember.Total,
            };
        }

        public async Task<FundMember> Update(int id, FundMemberEditRequest request)
        {
            var fundmember = await _context.FundMembers.FindAsync(id);
            if (fundmember == null)
            {
                throw new MemberManagementException("Không tìm thấy thành viên đóng quỹ");
            }

            fundmember.Id = request.Id;
            fundmember.Status = request.Status;
           fundmember.Total = request.Total;
            fundmember.FundId = request.FundId;
            fundmember.CreateDate = request.CreateDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy thành viên đóng quỹ");
                }
                else
                {
                    throw;
                }
            }
            return fundmember;
        }
    }
}
