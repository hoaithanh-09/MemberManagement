using MemberManagement.ViewModels.MemberViewModels;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class MemberController : BaseController
    {
        private readonly IMemberApiClient _iMemberApiClient;
        private readonly IConfiguration _configuration;

        public MemberController(IMemberApiClient iMemberApiClient, IConfiguration configuration)
        {
            _iMemberApiClient = iMemberApiClient;
            _configuration = configuration;
        }
        public async Task< IActionResult> Index(string keyword , int pageIndex =1 , int pageSize = 10  )
        {
            if (!ModelState.IsValid)
                return View();

            var request = new MemberPaingRequest()
            {
                KeyWord = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var data = await _iMemberApiClient.GetFamilyPaging(request);
            ViewBag.Keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MemberCreatRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _iMemberApiClient.Create(request);
            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo mới thành công";
                return RedirectToAction("Index", "Member");
            }
            return View(request);
        }


        public async Task< IActionResult> Edit(int id)
        {
            var member = await _iMemberApiClient.GetById(id);
            var request = new MemberEditRequest()
            {
                Name = member.Name,
                Birth = member.Birth,
                Gender = member.Gender,
                Idcard = member.Idcard,
                JoinDate = member.JoinDate,
                Notes = member.Notes,
            };
            return View(request);
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iMemberApiClient.GetById(id);
            return View(result);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id , MemberEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iMemberApiClient.Update(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var member = await _iMemberApiClient.GetById(id);
            var request = new MemberDeleteRequest()
            {
                Id = member.Id,
            };
            return View(request);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, MemberDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iMemberApiClient.Delete(request.Id);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }
    }
}
