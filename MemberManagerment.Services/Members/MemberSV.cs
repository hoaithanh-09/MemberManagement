using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.MemberViewModels;
using MemberManagerment.Data.EF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ManaberManagement.Utilities;
using MemberManagement.ViewModels.AddressMemberViewModels;
using MemberManagement.ViewModels.AddressViewModels;
using MemberManagement.ViewModels.ContactViewModels;
using MemberManagement.ViewModels.ContractMemberViewModels;
using MemberManagement.ViewModels.RoleMemberViewModels;
using MemberManagement.ViewModels.RoleViewModels;
using MemberManagement.Data.Entities;
using ClosedXML.Excel;

namespace MemberManagement.Services.Members
{
    public class MemberSV : IMemberSV
    {
        private readonly MemberManagementContext _context;
        public MemberSV(MemberManagementContext context)
        {
            _context = context;
        }

        public async Task<int> AddAddress(int memberId, AddressMemberCreateRequest request)
        {



            var address = await _context.Addresses.FindAsync(request.IdAddress);

            if (address == null)
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


        //public async Task<int> AddContact(int memberId, ContactMemberCreateRequest request)
        //{

           

        //    var contracMember = new ContactMembers()
        //    {
        //        MemberId = request.MemberId,
        //        ContactId = contact.Id,
        //    };

        //    _context.ContactMembers.Add(contracMember);
        //    await _context.SaveChangesAsync();
        //    return contact.Id;
        //}

        public async Task<int> AddRole(int memberId, RoleMemberCreateRequest request)
        {


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

        public async Task<ApiResult<string>> Create(MemberCreatRequest request)
        {
            var member = await _context.Members.FirstOrDefaultAsync(x => x.Idcard == request.Idcard);
            if (member != null)
            {
                return new ApiErrorResult<string>("Hội viên đã tồn tại");
            }
            var family = await _context.Families.FirstOrDefaultAsync(x => x.Id == request.FamilyId);
            var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == request.GroupId);
            if (group == null)
            {
                return new ApiErrorResult<string>("Chi hội không tồn lại");
            }
            if (request.FamilyId == 0)
            {
                var familyAdd = new Family()
                { 
                };

                _context.Add(familyAdd);
                _context.SaveChanges(); 
                var  f =  _context.Families.FirstOrDefault(x=>x.Id != 0 && x.IdMember ==0);
                member = new Member()
                {
                    Name = request.Name,
                    Gender = request.Gender,
                    Idcard = request.Idcard,
                    JoinDate = request.JoinDate,
                    Notes = request.Notes,
                    Group = group,
                    FamilyId = f.Id,
                    GroupId = request.GroupId,
                    Birth = request.Birth,
                    Email = request.Email,
                    Word = request.Word,
                    PersonalTtles = request.PersonalTtles,
                    PhoneNumber = request.PhoneNumber,
                };
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                f.IdMember = member.Id;
            }
            else
            {
                member = new Member()
                {
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
                    Email = request.Email,
                    Word = request.Word,
                    PersonalTtles = request.PersonalTtles,
                    PhoneNumber = request.PhoneNumber,
                };
                _context.Members.Add(member);
            }
           
            if (request.RoleId != 0)
            {
                member.RoleMembers = new List<RoleMember>()
                { new RoleMember()
                    {
                        RoleId =request.RoleId,
                        MemberId = member.Id,
                    }
                };
            }
          
            var a = await _context.SaveChangesAsync();
            if (a>0)
            {
                return new ApiSuccessResult<string>("Tạo thành công");

            }
            return new ApiErrorResult<string>("Tạo mới thất bại");
        }

        public async Task<string> Delete(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return "Không tìm thấy hội viên";
            }
            var memberRole = await _context.RoleMembers.AsQueryable().Where(x => x.MemberId == member.Id).ToListAsync();
            foreach (var memberr in memberRole)
            {
                _context.RoleMembers.Remove(memberr);
                await _context.SaveChangesAsync();
            }

            var AddreeMember = await _context.AddressMembers.AsQueryable().Where(x => x.MemberId == member.Id).ToListAsync();
            foreach (var address in AddreeMember)
            {
                _context.AddressMembers.Remove(address);
                await _context.SaveChangesAsync();
            }


            var contacts = await _context.ContactMembers.AsQueryable().Where(x => x.MemberId == member.Id).ToListAsync();
            foreach (var contact in contacts)
            {
                _context.ContactMembers.Remove(contact);
                await _context.SaveChangesAsync();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return "Xóa thành công";
        }

        public async Task<List<MemberVM>> GetAll()
        {
            var query = from f in _context.Members select f;
            var role = await query.Select(x => new MemberVM()
            {
                Name = x.Name,
                Gender = x.Gender,
                Idcard = x.Idcard,
                JoinDate = x.JoinDate,
                Notes = x.Notes,
                FamilyId = x.FamilyId,
                GroupId = x.GroupId,
                Birth = x.Birth,
                Email = x.Email,
                Word = x.Word,
                PersonalTtles = x.PersonalTtles,
                PhoneNumber = x.PhoneNumber,
                Id = x.Id,

            }).ToListAsync();

            return role;
        }

        public async Task<PagedResult<MemberVM>> GetAllPaging(MemberPaingRequest request)
        {
            var query = from m in _context.Members
                        join f in _context.Families on m.FamilyId equals f.Id
                        join g in _context.Groups on m.GroupId equals g.Id
                        select new { m, f, g };

            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.m.Name.Contains(request.KeyWord) || x.m.Idcard.Contains(request.KeyWord) );
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new MemberVM()
                {
                    Id = x.m.Id,
                    Name = x.m.Name,
                    Birth = x.m.Birth,
                    Gender = x.m.Gender,
                    Idcard = x.m.Idcard,
                    JoinDate = x.m.JoinDate,
                    Notes = x.m.Notes,
                    Email = x.m.Email,
                    PersonalTtles = x.m.PersonalTtles,
                    PhoneNumber = x.m.PhoneNumber,
                    Word = x.m.Word,
                    
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

        public async Task<MemberVM> GetById(int id)
        {
            var addresVM = new AddressVM();
            var contactVM = new ContactVM();
            var roleVM = new RoleVM();
            var member = await _context.Members.Include(x => x.AddressMembers).
                Where(x => x.Id == id).FirstOrDefaultAsync();
            if (member == null)
                throw new MemberManagementException("Không tìm thấy gia đình");

            var address = await _context.AddressMembers.Where(x => x.MemberId == id).FirstOrDefaultAsync();
            if (address != null)
            {
                var addresses = await _context.Addresses.Where(x => x.Id == address.AddressId).FirstOrDefaultAsync();
                addresVM = new AddressVM()
                {
                   
                    Nationality = addresses.Nationality,
                    Province = addresses.Province,
                    Ward = addresses.Ward,
                    District = addresses.District,
                    Notes = addresses.Notes,
                    StayingAddress = addresses.StayingAddress,
                };
            }
            var contactMember = await _context.ContactMembers.FirstOrDefaultAsync(x => x.MemberId == id);
            if (contactMember != null)
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == contactMember.ContactId);
                contactVM = new ContactVM()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Description = contact.Description,
                    Note = contact.Note,
                };
            }
            var roleMember = await _context.RoleMembers.FirstOrDefaultAsync(x => x.MemberId == id);
            if (roleMember != null)
            {
                var role = await _context.Roless.FirstOrDefaultAsync(x => x.Id == roleMember.RoleId);
                roleVM = new RoleVM()
                {
                    Name = role.Name,
                    Description = role.Description,
                    Note = role.Note,
                };
            }
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
                FamilyId = member.FamilyId,
                GroupId = member.GroupId,
                Id = member.Id,
                Name = member.Name,
                Birth = member.Birth,
                Gender = member.Gender,
                JoinDate = member.JoinDate,
                Idcard = member.Idcard,
                Email = member.Email,
                PersonalTtles = member.PersonalTtles,
                Word = member.Word,
                PhoneNumber = member.PhoneNumber,
                Notes = member.Notes,
                AddressMembers = addressMember,
                ContactMembers = contractMember,
                RoleMembers = roleMembers,
            };
            return memberVN;
        }
        public async Task<Member> Update(int id, MemberEditRequest request)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                throw new MemberManagementException("Không tìm thấy địa chỉ");
            }
          

            member.Name = request.Name;
             member.Birth = request.Birth;
            member.Gender = request.Gender;
            member.Idcard = request.Idcard;
            member.JoinDate = request.JoinDate;
            member.Notes = request.Notes;
           
            member.Email = request.Email;
            member.Word = request.Word;
            member.PersonalTtles = request.PersonalTtles;
            member.PhoneNumber = request.PhoneNumber;

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
        public async Task<XLWorkbook> ExportMember()
        {
            var members = await GetAll();
           
            var t = Task.Run(() =>
            {
                var workbook = new XLWorkbook();
                IXLWorksheet worksheet = workbook.Worksheets.Add("Danh sách hôi viên");

                int column = 1;
                int row = 3;
                worksheet.Cell(row, column++).Value = "STT";
                worksheet.Cell(row, column++).Value = "Tên học sinh";
                worksheet.Cell(row, column++).Value = "Giới tính";
                worksheet.Cell(row, column++).Value = "CMND";
                worksheet.Cell(row, column++).Value = "Số điện thoại";
                worksheet.Cell(row, column++).Value = "Gmail";
                worksheet.Cell(row, column++).Value = "Nghề nghiệp";
                worksheet.Cell(row, column++).Value = "Chức danh cá nhân";
                worksheet.Cell(row, column++).Value = "Ghi chú";


                #region style
                worksheet.Column(1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Cell("B3").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Column(3).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Column(4).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Column(5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Column(6).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Column(7).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Column(8).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                worksheet.Column(9).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);


                //Bold TITLE ROW
                worksheet.Row(2).Style.Font.Bold = true;
                worksheet.Row(2).Style.Font.FontSize = 15;
                worksheet.Row(3).Style.Font.Bold = true;
                #endregion
                row = 4;
                int number = 1;
                foreach (var member in members)
                {
                    column = 1; 
                    worksheet.Cell(row, column++).SetValue(number);
                    worksheet.Cell(row, column++).SetValue(member.Name);
                    worksheet.Cell(row, column++).SetValue(member.Gender);
                    worksheet.Cell(row, column++).SetValue(member.Idcard);
                    worksheet.Cell(row, column++).SetValue(member.PhoneNumber);
                    worksheet.Cell(row, column++).SetValue(member.Email);
                    worksheet.Cell(row, column++).SetValue(member.Word);
                    worksheet.Cell(row, column++).SetValue(member.PersonalTtles);
                    worksheet.Cell(row, column++).SetValue(member.Notes);
                    ++row;
                    number++;


                }
                worksheet.RangeUsed().Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
                worksheet.RangeUsed().Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);

                //other style all cell
                worksheet.CellsUsed().Style.Alignment.SetWrapText(true);
                worksheet.ColumnsUsed().AdjustToContents();
                worksheet.SheetView.FreezeRows(1);
                return workbook;



            });
            return await t;


        }

    }
}
