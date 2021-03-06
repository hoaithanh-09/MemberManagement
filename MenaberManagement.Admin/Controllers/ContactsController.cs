using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.ContactViewModels;
using MemberManagement.ViewModels.ContractMemberViewModels;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactApiClientcs _iContactApiClient;
        private readonly IConfiguration _configuration;

        private readonly IRoleApiClient _iRoleApiClient;
        private readonly IMemberApiClient _iMemberApiClient;

        public ContactsController(IContactApiClientcs iContactApiClient, IRoleApiClient iRoleApiClient, IMemberApiClient iMemberApiClient,
        IConfiguration configuration)
        {
            _configuration = configuration;
            _iContactApiClient = iContactApiClient;
            _iMemberApiClient = iMemberApiClient;
            _iRoleApiClient = iRoleApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetContactPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _iContactApiClient.GetFamilyPaging(request);
            ViewBag.Keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        // GET: FamiliesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iContactApiClient.GetById(id);
            return View(result);
        }

        // GET: FamiliesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamiliesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iContactApiClient.Create(request);
            if (!result)
            {
                ModelState.AddModelError("", "Tạo mới thất bại");
                return View(request);
            }
            if (result)
            {
                TempData["result"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Contacts");
            }
            return View(request);
        }

        // GET: FamiliesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var result = await _iContactApiClient.GetById(id);

            if (result != null)
            {
                var family = new ContactEditRequest()
                {
                    Name = result.Name,
                    Description = result.Description,
                    Note = result.Note,
                };
                return View(family);
            };
            return View(StatusCodes.Status400BadRequest);
        }

        // POST: FamiliesController/Edit/5
        [HttpPut]
        public async Task<ActionResult> Edit(int id, ContactEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iContactApiClient.Update(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
            return View(request);
        }

        // GET: FamiliesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _iContactApiClient.GetById(id);

            if (result != null)
            {
                var family = new ContactDeleteRequest()
                {
                    Id = id,
                };
                return View(family);
            }
            return View(StatusCodes.Status400BadRequest);
        }

        // POST: FamiliesController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ContactDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iContactApiClient.Delete(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa người dùng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa thất bại");
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> ListMember(int id)
        {
            var roleAssignRequest = await ListMemberContact(id);

            return View(roleAssignRequest);
        }

        private async Task<GetContactPagedResult<ExMembers>> ListMemberContact(int id)
        {
            var request = new GetContactPagingRequest()
            {
                Keyword = "",
                PageIndex = 1,
                PageSize = 10,
            };
            var data = await _iContactApiClient.ListMember(id, request);
            var re = new GetContactPagedResult<ExMembers>();

            re.Items = data.Items;
            re.PageCount = data.PageCount;
            re.PageIndex = data.PageIndex;
            re.PageSize = data.PageSize;
            re.IdContact = id;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return re;
        }
        [HttpGet("AddMember/{id}")]
        public async Task<IActionResult> AddMember(int id)
        {
            var member = new ContactMemberCreateRequest();
            var a = await _iMemberApiClient.GetAll();
            var b = await _iRoleApiClient.GetAll();
            member.Members = a;
            member.Roles = b;
            member.IdContact = id;
            return View(member);
        }

        [HttpPost("AddMember/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMember([FromRoute]int id, [FromForm] ContactMemberCreateRequest idMember)
        {
            var family = await _iContactApiClient.AddMember(id, idMember);
            return RedirectToAction("Index", "Contacts");
        }
        [HttpGet("RemoveMember/{id}")]
        public async Task<ActionResult> RemoveMember(int id)
        {
            var result = await _iContactApiClient.GetById(id);

            if (result != null)
            {
                var family = new ContactDeleteRequest()
                {
                    Id = id,
                };
                return View(family);
            }
            return View(StatusCodes.Status400BadRequest);
        }

        // POST: FamiliesController/Delete/5
        [HttpPost("RemoveMember/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveMember([FromRoute] int id, [FromForm] ContactDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iContactApiClient.Delete(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa người dùng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa thất bại");
            return View();


        }
    }
}
