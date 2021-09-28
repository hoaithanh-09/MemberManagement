using MemberManagement.ViewModels.GroupViewModels;
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
    public class GroupController : BaseController
    {
        private readonly IGroupApiClient _iGroupApiClient;
        private readonly IConfiguration _configuration;


        public GroupController(IGroupApiClient iGroupApiClient,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _iGroupApiClient = iGroupApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetGroupPagingRequest()
            {
                KeyWord = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _iGroupApiClient.GetFamilyPaging(request);
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
            var result = await _iGroupApiClient.GetById(id);
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
        public async Task<ActionResult> Create(GroupCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iGroupApiClient.Create(request);
            if (!result)
            {
                ModelState.AddModelError("", "Tạo mới thất bại");
                return View(request);
            }
            if (result)
            {
                TempData["result"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Group");
            }
            return View(request);
        }

        // GET: FamiliesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var result = await _iGroupApiClient.GetById(id);

            if (result != null)
            {
                var family = new GroupEditRequest()
                {
                    Name = result.Name,
                    Description = result.Description,
                    Region = result.Region,
                };
                return View(family);
            };
            return View(StatusCodes.Status400BadRequest);
        }

        // POST: FamiliesController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, GroupEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iGroupApiClient.Update(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }

        // GET: FamiliesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _iGroupApiClient.GetById(id);

            if (result != null)
            {
                var family = new GroupDeleteRequest()
                {
                    Id = id,
                };
                return View(family);
            }
            return View(StatusCodes.Status400BadRequest);
        }

        // POST: FamiliesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, GroupDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iGroupApiClient.Delete(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa thất bại");
            return View();
        }
    }
}
