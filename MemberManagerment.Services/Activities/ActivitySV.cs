using MemberManagement.Data.Entities;
using MemberManagement.ViewModels.ActivityViewModels;
using MemberManagement.ViewModels.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManaberManagement.Utilities;
using MemberManagement.ViewModels.ActivityMemberViewModels;
using MemberManagement.ViewModels.MemberViewModels;
using MemberManagerment.Data.EF;

namespace MemberManagement.Services.Activities
{
    public class ActivitySV : IActivitySV
    {
        private readonly MemberManagementContext _context;
        public ActivitySV(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<int> AddMember(int activityId, ActivityMemberCreateRequest request)
        {
            var member = await _context.Members.FindAsync(request.MemberId);

            if (member == null)
            {
                throw new MemberManagementException("Thông tin không hợp lệ");
            }

            var activityMember = new ActivityMember()
            {
                MemberId = member.Id,
                ActivityId = request.ActivityId,
            };

            _context.ActivityMembers.Add(activityMember);
            await _context.SaveChangesAsync();
            return activityMember.MemberId;
        }

        public async Task<ApiResult<string>> Create(ActivityCreateRequest request)
        {
            var activityAdd = new Activity()
            {
                Name = request.Name,
                Description = request.Description,
                Content = request.Content,
                CreatedDate = request.CreatedDate,
                Cost = request.Cost
            };

            _context.Activities.Add(activityAdd);

            if (request.MemberId != 0)
            {
                activityAdd.FundMembers = new List<FundMember>()
                { new FundMember()
                    {
                       MemberId = request.MemberId,
                       FundId = activityAdd.Id,
                    }
                };
            }
            var a = await _context.SaveChangesAsync();
            if (a > 0)
            {
                return new ApiSuccessResult<string>("Tạo thành công");

            }
            return new ApiErrorResult<string>("Tạo mới thất bại");

        }

        public async Task<int> Delete(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                throw new MemberManagementException("Không tìm thấy!");
            }
            var activityMember = await _context.ActivityMembers.AsQueryable().Where(x => x.ActivityId == activity.Id).ToListAsync();
            foreach (var member in activityMember)
            {
                _context.ActivityMembers.Remove(member);
                await _context.SaveChangesAsync();
            }

            _context.Activities.Remove(activity);
            return await _context.SaveChangesAsync();
            
        }

        public async Task<List<ActivityVM>> GetAll()
        {
            var query = from f in _context.Activities select f;
            var role = await query.Select(x => new ActivityVM()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                Cost = x.Cost

            }).ToListAsync();

            return role;
        }

        public async Task<ActivityVM> GetById(int id)
        {
            var memberVM = new MemberVM();
            var activity = await _context.Activities.Include(x => x.ActivityMembers).
                Where(x => x.Id == id).FirstOrDefaultAsync();
            if (activity == null)
                throw new MemberManagementException("Không tìm thấy!");

            var activityMember = await _context.ActivityMembers.Where(x => x.ActivityId == id).FirstOrDefaultAsync();
            if (activityMember != null)
            {
                var member = await _context.Members.Where(x => x.Id == activityMember.MemberId).FirstOrDefaultAsync();
                memberVM = new MemberVM()
                {
                    Name = member.Name,
                    PersonalTtles=member.PersonalTtles,                  
                };
            }
           
            
            var activityMembers = new ActivityMemberVM()
            {
                 Member= memberVM,
            };

            var activityVM = new ActivityVM()
            {
                Id = activity.Id,
                Name= activity.Name,
                Content= activity.Content,
                Cost=activity.Cost,
                CreatedDate= activity.CreatedDate,
                Description= activity.Description,
                ActivityMembers= activityMember,
            };
            return activityVM;
        }

        public async Task<PagedResult<ActivityVM>> GetPagedResult(GetActivityPagingRequest request)
        {
            var query = from f in _context.Activities select f;

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword));

            int totalRow = await query.CountAsync();

            var data = await query.OrderBy(x => x.Id).Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ActivityVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    Cost = x.Cost

                }).ToListAsync();

            var pagedResult = new PagedResult<ActivityVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<Activity> Update(int id, ActivityEditRequest request)
        {
            var rold = await _context.Activities.FindAsync(id);
            if (rold == null)
            {
                throw new MemberManagementException("Không tìm thấy hoạt động !");
            }
            rold.Name = request.Name;
            rold.Description = request.Description;
            rold.Content = request.Content;
            rold.CreatedDate = request.CreatedDate;
            rold.Cost = request.Cost;

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
