using MemberManagement.ViewModels.AddressViewModels;
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
    public class AddressController : BaseController
    {
        private readonly IAddressApiClient _iAddressApiClient;
        private readonly IConfiguration _configuration;


        public AddressController(IAddressApiClient iAddressApiClient,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _iAddressApiClient = iAddressApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetAddressPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _iAddressApiClient.GetFamilyPaging(request);
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
            var result = await _iAddressApiClient.GetById(id);
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
        public async Task<ActionResult> Create(AddressCreatRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iAddressApiClient.Create(request);
            if (!result)
            {
                ModelState.AddModelError("", "Tạo mới thất bại");
                return View(request);
            }
            if (result)
            {
                TempData["result"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Address");
            }
            return View(request);
        }

        // GET: FamiliesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var result = await _iAddressApiClient.GetById(id);

            if (result != null)
            {
                var family = new AddressEditRequest()
                {
                    Nationality = result.Nationality,
                Province = result.Province,
                Ward = result.Ward,
                District = result.District,
                StayingAddress = result.StayingAddress,
                Notes = result.Notes,
            };
                return View(family);
            };
            return View(StatusCodes.Status400BadRequest);
        }

        // POST: FamiliesController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, AddressEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iAddressApiClient.Update(id, request);
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
            var result = await _iAddressApiClient.GetById(id);

            if (result != null)
            {
                var family = new AddressDeleteRequest()
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
        public async Task<ActionResult> Delete(int id, AddressDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iAddressApiClient.Delete(request.Id);
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
