using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.MemberViewModels;
using MemberManagerment.Data.EF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MemberManagerment.Data.Entities;
using ManaberManagement.Utilities;
using MemberManagement.ViewModels.AddressMemberViewModels;
using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.ContactViewModels;
using MemberManagement.ViewModels.ContractMemberViewModels;
using MemberManagement.ViewModels.RoleMemberViewModels;
using MemberManagement.ViewModels.RoleViewModels;

namespace MemberManagement.Services.Members
{
    public class MemberSV : IMemberSV
    {
        private readonly MemberManagementContext _context;
        public MemberSV(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<string> AddAddress(string memberId, AddressMemberCreateRequest request)
        {

            if (string.IsNullOrEmpty(request.IdAddress) || string.IsNullOrEmpty(request.IdAddress))
            {
                throw new MemberManagementException("chưa nhập địa chỉ");
            }

            var address = await _context.Addresses.FindAsync(request.IdAddress);

            if(address==null)
            {
                throw new MemberManagementException("địa chỉ không hợp lệ");
            }

            var addressMember = new AddressMember()
            {
                MemberId = request.IdMember,
                AddressId = address.Id,
            };

            _context.AddressMembers.Add(addressMember);
            await _context.SaveChangesAsync();
            return address.Id;
        }


        public async Task<string> AddContact(string memberId, ContactMemberCreateRequest request)
        {

            if (string.IsNullOrEmpty(request.MemberId) || string.IsNullOrEmpty(request.ContactId))
            {
                throw new MemberManagementException("chưa nhập liên hệ");
            }

            var contact = await _context.Addresses.FindAsync(request.ContactId);

            if (contact == null)
            {
                throw new MemberManagementException("Thông tin không hợp lệ");
            }  

            var contracMember = new ContactMember()
            {
                MemberId = request.MemberId,
                ContactId = contact.Id,
            };

            _context.ContactMembers.Add(contracMember);
            await _context.SaveChangesAsync();
            return contact.Id;
        }

        public async Task<string> AddRole(string memberId, RoleMemberCreateRequest request)
        {
            if (string.IsNullOrEmpty(request.MemberId) || string.IsNullOrEmpty(request.RoleId))
            {
                throw new MemberManagementException("chưa nhập vai trò");
            }

            var role = await _context.Roless.FindAsync(request.RoleId);

            if (role == null)
            {
                throw new MemberManagementException("Thông tin không hợp lệ");
            }

            var roleMember = new RoleMember()
            {
                MemberId = request.MemberId,
                RoleId = role.Id,
            };

            _context.RoleMembers.Add(roleMember);
            await _context.SaveChangesAsync();
            return roleMember.RoleId;
        }

        public async Task<string> Create(MemberCreatRequest request)
        {
            var member = await _context.Members.FindAsync(request.Idcard);
            if (member != null)
            {
                throw new MemberManagementException("Hội viên đã tồn tại");
            }

            var family = await _context.Families.FindAsync(request.FamilyId);
            if(family == null)
            {
                throw new MemberManagementException("Gia đình chưa tồn tại");
            }
            var group = await _context.Groups.FindAsync(request.GroupId);
            if (group == null)
            {
                throw new MemberManagementException("Chi hội chưa tồn tại");
            }
            
            member = new Member()
            {
                Id = DateTime.Now.Minute.ToString(),
                Name = request.Name,
                Gender = request.Gender,
                Idcard = request.Idcard,
                JoinDate = request.JoinDate,
                Notes = request.Notes,
                Family = family,
                Group = group,
                FamilyId = request.FamilyId,
                GroupId = request.GroupId,
                Birth = request.Birth,
                ImageId = "Sdasdas",           
            };
           
            if(request.IdAddress != null)
            {
                member.AddressMembers = new List<AddressMember>()
                { new AddressMember()
                    {
                        AddressId =request.IdAddress,
                        MemberId = member.Id,
                    }
                };
            }

            _context.Add(member);
            await _context.SaveChangesAsync();
            return member.Id;
        }

        public async Task<PagedResult<MemberVM>> GetAllPaging(MemberPaingRequest request)
        {
            var query = from m in _context.Members
                        join f in _context.Families on m.FamilyId equals f.Id
                        join g in _context.Groups on m.GroupId equals g.Id
                        select new { m, f,g };

            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.m.Name.Contains(request.KeyWord));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new MemberVM()
                {
                   Name = x.m.Name,
                   Birth = x.m.Birth,
                   Gender = x.m.Gender,
                   Idcard = x.m.Idcard,
                   JoinDate = x.m.JoinDate,
                   Notes = x.m.Notes,
                }).ToListAsync();
            var paging = new PagedResult<MemberVM>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = totalRow,
                Items = data,
            };
            return paging;
        }

        public async Task<MemberVM> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new MemberManagementException("Vui lòng nhập id");
            var member = await _context.Members.Include(x => x.AddressMembers).
                Where(x => x.Id == id).FirstOrDefaultAsync();
            if (member == null)
                throw new MemberManagementException("Không tìm thấy gia đình");
            
            var address = await _context.AddressMembers.Where(x=>x.MemberId == id).FirstOrDefaultAsync();
            var addresses = await _context.Addresses.Where(x => x.Id == address.AddressId).FirstOrDefaultAsync();


            var contactMember = await _context.ContactMembers.Where(x => x.MemberId == id).FirstOrDefaultAsync();
            var contact = await _context.Contacts.Where(x => x.Id == contactMember.ContactId).FirstOrDefaultAsync();

            var roleMember = await _context.RoleMembers.Where(x => x.MemberId == id).FirstOrDefaultAsync();
            var role = await _context.Roless.Where(x => x.Id == roleMember.RoleId).FirstOrDefaultAsync();

            var addresVM = new AddressVM()
            {
                Nationality = addresses.Nationality,
                Province = addresses.Province,
                Ward = addresses.Ward,
                District = addresses.District,
                Notes = addresses.Notes,
                StayingAddress = addresses.StayingAddress,
            };
            var contactVM = new ContactVM()
            {
                FullName = contact.FullName,
                Nickname = contact.Nickname,
                PersonalTtles = contact.PersonalTtles,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Word = contact.Word,
                UserName = contact.UserName,
                Notes = contact.Notes,
            };

            var roleVM = new RoleVM()
            {
                Name = role.Name,
                Description = role.Description,
                Note = role.Note,
            };

            var roleMembers = new RoleMemberVM()
            {
                 Role = roleVM,
            };
            var addressMember = new AddressMemberVM()
            {
                Address = addresVM,
            };

            var contractMember = new ContactMemberVM()
            {
                Contact = contactVM,
            };



            var memberVN = new MemberVM()
            {
                Name = member.Name,
                Birth = member.Birth,
                Gender = member.Gender,
                JoinDate = member.JoinDate,
                Idcard = member.Idcard,
                Notes = member.Notes,
                AddressMembers = addressMember,
                ContactMembers = contractMember,
                RoleMembers = roleMembers,
            };
            return memberVN;
        }

        public async Task<Member> Update(string id, MemberEditRequest request)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                throw new MemberManagementException("Không tìm thấy địa chỉ");
            }
            member.Name = request.Name;
            member.Birth = request.Birth;
            member.Gender = request.Gender;
            member.JoinDate = request.JoinDate;
            member.Idcard = request.Idcard;
            member.Notes = request.Notes;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetById(id) == null)
                {
                    throw new MemberManagementException("Không tìm thấy địa chỉ");
                }
                else
                {
                    throw;
                }
            }
            return member;
        }

        
        
    }
}
