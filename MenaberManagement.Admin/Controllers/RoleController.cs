using MemberManagement.ViewModels.RoleViewModels;
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
    public class RoleController : BaseController
    {
        private readonly IRoleApiClient _iRoleApiClient;
        private readonly IConfiguration _configuration;


        public RoleController(IRoleApiClient iRoleApiClient,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _iRoleApiClient = iRoleApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetRolePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _iRoleApiClient.GetFamilyPaging(request);
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
            var result = await _iRoleApiClient.GetById(id);
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
        public async Task<ActionResult> Create(RoleCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iRoleApiClient.Create(request);
            if (!result)
            {
                ModelState.AddModelError("", "Tạo mới thất bại");
                return View(request);
            }
            if (result)
            {
                TempData["result"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Role");
            }
            return View(request);
        }

        // GET: FamiliesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var result = await _iRoleApiClient.GetById(id);

            if (result != null)
            {
                var family = new RoleEditRequest()
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
        [HttpPost]
        public async Task<ActionResult> Edit(int id, RoleEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iRoleApiClient.Update(id, request);
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
            var result = await _iRoleApiClient.GetById(id);

            if (result != null)
            {
                var family = new RoleDeleteRequest()
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
        public async Task<ActionResult> Delete(int id, RoleDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iRoleApiClient.Delete(request.Id);
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
