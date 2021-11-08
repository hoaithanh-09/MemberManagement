using ManaberManagement.Utilities;
using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FundGroupVIewModels;
using MemberManagement.ViewModels.FundMemberViewModels;
using MemberManagement.ViewModels.FundViewModels;
using MemberManagement.ViewModels.GroupViewModels;
using MemberManagement.ViewModels.MemberViewModels;
using MemberManagerment.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Services.Funds
{
    public class FundSV : IFundSV
    {
        private readonly MemberManagementContext _context;
        public FundSV(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAction(int fundId, FundGroupCreateRequest request)
        {
            /*var group = _context.Groups.Find(request.GroupId);
            if (group == null)
            {
                return false;
            }*/
            var memberContact = new FundGroup()
            {
                GroupId = request.Id,
                FundId = fundId,
                Name = request.Name,
                Description = request.Description,
                CreateDate = DateTime.Now,
                Money = request.Money,
                Finish = request.Finish,
            };
            _context.FundGroups.Add(memberContact);
            int a = await _context.SaveChangesAsync();
            if (a <= 0)
            {
                return false;
            }
            return true;

        }


        public async Task<ApiResult<string>> Create(FundCreateRequest request)
        {
            var fund = new Fund()
            {
                Name = request.Name,
                CreatedDate = request.CreatedDate,
                Description = request.Description,
                TotalFund = request.TotalFund,
            };

            _context.Funds.Add(fund);
           

            var a = await _context.SaveChangesAsync();
            if (a > 0)
            {
                return new ApiSuccessResult<string>("Tạo thành công");

            }
            return new ApiErrorResult<string>("Tạo mới thất bại");



        }

        public async Task<int> Delete(int id)
        {
            var fund = await _context.Funds.FindAsync(id);
            if (fund == null)
            {
                throw new MemberManagementException("Không tìm thấy!");
            }
            var fundMember = await _context.FundGroups.AsQueryable().Where(x => x.FundId == fund.Id).ToListAsync();
            foreach (var member in fundMember)
            {
                _context.FundGroups.Remove(member);
                await _context.SaveChangesAsync();
            }

            _context.Funds.Remove(fund);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<FundVM>> GetAll()
        {
            var query = from f in _context.Funds select f;
            var role = await query.Select(x => new FundVM()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                TotalFund = x.TotalFund


            }).ToListAsync();

            return role;
        }

        public async Task<FundVM> GetById(int id)
        {
            var groupVM = new GroupVM();
            var activity = await _context.Funds.Include(x => x.FundGroups).
                Where(x => x.Id == id).FirstOrDefaultAsync();
            if (activity == null)
                throw new MemberManagementException("Không tìm thấy!");

            var activityMember = await _context.FundGroups.Where(x => x.FundId == id).FirstOrDefaultAsync();
            if (activityMember != null)
            {
                var member = await _context.Groups.Where(x => x.Id == activityMember.GroupId).FirstOrDefaultAsync();
                groupVM = new GroupVM()
                {
                    Name = member.Name,
                    Id=member.Id,
                };
            }


            var activityMembers = new FundGroupVM()
            {
                Group = groupVM,
            };

            var activityVM = new FundVM()
            {
                Id = activity.Id,
                Name = activity.Name,
                Description = activity.Description,
                TotalFund=activity.TotalFund,
                CreatedDate=activity.CreatedDate,
                FundGroups = activityMember,
            };
            return activityVM;
        }

        public async Task<PagedResult<FundVM>> GetPagedResult(GetFundPagingRequest request)
        {
            var query = from f in _context.Funds select f;

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword));

            int totalRow = await query.CountAsync();

            var data = await query.OrderBy(x => x.Id).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new FundVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    TotalFund = x.TotalFund,
                    CreatedDate = x.CreatedDate,

                }).ToListAsync();

            var pagedResult = new PagedResult<FundVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<ListAction>> ListAction(int fundId, GetFundPagingRequest request)
        {
            var listAction = new List<ListAction>();
            var listFundMember = await _context.FundGroups.AsQueryable().Where(x => x.FundId == fundId).ToListAsync();
            foreach (var fundMember in listFundMember)
            {
                var gr = _context.Groups.Find(fundMember.GroupId);
                var action1 = _context.FundGroups.Find(fundMember.Id);
                var action = new ListAction()
                {
                    Id = action1.Id,
                    Name = action1.Name,
                    Description = action1.Description,
                    CreateDate=action1.CreateDate,
                    Finish=action1.Finish,
                    Money= action1.Money,
                    NameGroup = gr.Name,
                };
                listAction.Add(action);
            }
            var pagedResult = new PagedResult<ListAction>
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = listAction.Count,
                Items = listAction,
            };
            return pagedResult;
        }

        public Task<bool> RomoveAction(int fundId, int idMember)
        {
            throw new NotImplementedException();
        }

        public   Task<bool> RomoveMember(int fundId, int idMember)
        {
            /*var fund = await _context.FundMembers.Where(x => x.FundId == fundId
            && x.MemberId == idMember).FirstOrDefaultAsync();
            if (fund != null)
            {
                _context.Remove(fund);

            }
            int a = await _context.SaveChangesAsync();
            if (a <= 0)
            {
                return false;
            }
            return true;*/
            throw new NotImplementedException();
        }

        public async Task<Fund> Update(int id, FundEditRequest request)
        {
            var rold = await _context.Funds.FindAsync(id);
            if (rold == null)
            {
                throw new MemberManagementException("Không tìm thấy hoạt động !");
            }
            rold.Name = request.Name;
            rold.Description = request.Description;
            rold.TotalFund = request.TotalFund;
            rold.CreatedDate = request.CreatedDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy hoạt động");
                }
                else
                {
                    throw;
                }
            }
            return rold;
        }

       
    }
}
