using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FamilyViewModels;
using MemberManagement.ViewModels.MemberViewModels;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class MemberController : BaseController
    {
        private readonly IGroupApiClient _iGroupApiClient;
        private readonly IMemberApiClient _iMemberApiClient;
        private readonly IConfiguration _configuration;
        private readonly IFamilyApiClient _familyApiClient;
        private readonly IAddressApiClient _iAddressApiClient;
        private readonly IRoleApiClient _iRoleApiClient;
        private readonly IContactApiClientcs _iContactApiClient;
        public MemberController(
            IMemberApiClient iMemberApiClient,
            IConfiguration configuration,
            IFamilyApiClient familyApiClient,
            IGroupApiClient iGroupApiClient,
            IAddressApiClient iAddressApiClient,
            IRoleApiClient iRoleApiClient,
            IContactApiClientcs iContactApiClient
            )
        {
            _iMemberApiClient = iMemberApiClient;
            _configuration = configuration;
            _familyApiClient = familyApiClient;
            _iGroupApiClient = iGroupApiClient;
            _iAddressApiClient = iAddressApiClient;
            _iRoleApiClient = iRoleApiClient;
            _iContactApiClient = iContactApiClient;
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
        public async Task<IActionResult> Create()
        {

            var familtObj = await _familyApiClient.GetAll();
            //ViewBag.HousldRepre = new SelectList(familtObj, "Id", "Id");

            var GoupObj = await _iGroupApiClient.GetAll();

            var addObj = await _iAddressApiClient.GetAll();

            var roles = await _iRoleApiClient.GetAll();
            var contact = await _iContactApiClient.GetAll();
            var memberCreatRequest = new MemberCreatRequest();
            ViewBag.address = new SelectList(addObj, "Id", "Province");

            memberCreatRequest.familyVMs = familtObj;
            memberCreatRequest.groupVMs = GoupObj;
            memberCreatRequest.Address = addObj;
            memberCreatRequest.Roles = roles;
            memberCreatRequest.Contacts = contact;
            return View(memberCreatRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MemberCreatRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var familtObj = await _familyApiClient.GetAll();
            //ViewBag.HousldRepre = new SelectList(familtObj, "Id", "Id");

            var GoupObj = await _iGroupApiClient.GetAll();
            //ViewBag.Group = new SelectList(GoupObj, "Id", "Id");

            var addObj = await _iAddressApiClient.GetAll();

            var roles = await _iRoleApiClient.GetAll();
            var contact = await _iContactApiClient.GetAll();

            request.familyVMs = familtObj;
            request.groupVMs = GoupObj;
            request.Address = addObj;
            request.Roles = roles;
            request.Contacts = contact;

            var result = await _iMemberApiClient.Create(request);
            
            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }
            if (result.IsSuccessed)
            {
                TempData["result"] = result.ResultObj;
                return RedirectToAction("Index", "Member");
            }
            return View(request);
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iMemberApiClient.GetById(id);
            return View(result);
        }
        public async void SetViewBag(int? seletedId = null)
        {
            var roleObj = await _familyApiClient.GetAll();

            ViewBag.HousldRepre = new SelectList(roleObj, "Id", "HousldRepre", seletedId);
        }

        public async Task<IActionResult> Edit(int id)
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

        [HttpPost]
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

        [HttpPost]
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
