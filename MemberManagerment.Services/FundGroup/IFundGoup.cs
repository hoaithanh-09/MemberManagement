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
    public interface IFundGoupService
    {
        Task<ApiResult<string>> Create(FundGoupCreateRequest request);
        Task<string> Delete(int id);
        Task<FundGoupVM> GetById(int id);
        Task<FundGroup> Update(int id, FundGoupEditRequest request);

        Task<PagedResult<FundGoupVM>> GetPaged(int FundId, GetFundPagingRequest request);
    }
   
    public class FundGoupService : IFundGoupService
    {
        private readonly MemberManagementContext _context;

        public FundGoupService(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<string>> Create(FundGoupCreateRequest request)
        {
            var funmember = new FundGroup()
            {
                Id = request.Id,
                CreateDate = request.CreateDate,
                FundId = request.FundId,
                Description = request.Description,
                Finish = request.Finish,
                GroupId = request.GroupId,
                Money = request.Money,
                Name = request.Name,
            };
            _context.FundGroups.Add(funmember);
            var a = await _context.SaveChangesAsync();
            if (a > 0)
            {
                return new ApiSuccessResult<string>("Tạo thành công");

            }
            return new ApiErrorResult<string>("Tạo mới thất bại");
        }
        public async Task<PagedResult<FundGoupVM>> GetPaged(int FundId, GetFundPagingRequest request)
        {
            var fun = await _context.FundGroups.AsQueryable().Where(x => x.FundId == FundId).Select( y=>new FundGoupVM()
            {
                Id=y.Id,
                CreateDate=y.CreateDate,
                Description=y.Description,
                Finish=y.Finish,
                FundId=y.FundId,
                GroupId=y.GroupId,
                Money=y.Money,
                Name   = y.Name,
            }).ToListAsync();
            var pagedResult = new PagedResult<FundGoupVM>()
            {
                Items = fun,
                PageCount = fun.Count,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
                            
            };
            return pagedResult;
        }


        public async Task<string> Delete(int id)
        {
            var fundMembers = await _context.FundGroups.FindAsync(id);
            _context.FundGroups.Remove(fundMembers);
            int a = await _context.SaveChangesAsync();
            if (a > 0)
                return "Xóa thành công";
            return "Xóa thất bại";
        }

        public async Task<FundGoupVM> GetById(int id)
        {
            var fundmember = await _context.FundGroups.FindAsync(id);
            if (fundmember == null)
            {
                throw new MemberManagementException("Không tìm thấy thành viên đóng quỹ");
            }
            return new FundGoupVM()
            {
                Id = fundmember.Id,
                CreateDate = fundmember.CreateDate,
                FundId = fundmember.FundId,
                Description = fundmember.Description,
                Name = fundmember.Name,
                Money = fundmember.Money,
                Finish = fundmember.Finish,
            };
        }

     

        public async Task<FundGroup> Update(int id, FundGoupEditRequest request)
        {
            var fundmember = await _context.FundGroups.FindAsync(id);
            if (fundmember == null)
            {
                throw new MemberManagementException("Không tìm thấy thành viên đóng quỹ");
            }

            fundmember.Id = request.Id;
            fundmember.FundId = request.FundId;
            fundmember.GroupId = request.GroupId;
            fundmember.CreateDate = request.CreateDate;
            fundmember.Money = request.Money;
            fundmember.Name = request.Name;
            fundmember.Description = request.Description;
            fundmember.Finish = request.Finish;

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
