using MemberManagement.ViewModels.ActivityViewModels;
using MenaberManagement.Admin.Models;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class ActivitiesController : BaseController
    {
        private readonly IActivityApi _iActivityApi;
        private readonly IConfiguration _configuration;
        private readonly IMemberApiClient _iMemberApiClient;
        public ActivitiesController(
            IMemberApiClient iMemberApiClient,
            IConfiguration configuration,
            IActivityApi iActivityApi          
            )
        {
            _iMemberApiClient = iMemberApiClient;
            _configuration = configuration;
            _iActivityApi = iActivityApi;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            if (!ModelState.IsValid)
                return View();

            var request = new GetActivityPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var data = await _iActivityApi.GetActivityPaging(request);
            ViewBag.Keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);

        }
        public async Task<IActionResult> Create()
        {
            CascadingModel model = new CascadingModel();


            var members = await _iMemberApiClient.GetAll();
            var activityCreatRequest = new ActivityCreateRequest();

            activityCreatRequest.Members = members;
            return View(activityCreatRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ActivityCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var members = await _iMemberApiClient.GetAll();
            request.Members = members;

            var result = await _iActivityApi.Create(request);

            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }
            if (result.IsSuccessed)
            {
                TempData["result"] = result.ResultObj;
                return RedirectToAction("Index", "Activities");
            }
            return View(request);
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iActivityApi.GetById(id);
            return View(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var activity = await _iActivityApi.GetById(id);
            var request = new ActivityEditRequest()
            {
                Name = activity.Name,
                Content = activity.Content,
                Cost = activity.Cost,
                Description = activity.Description,
                CreatedDate = activity.CreatedDate,
            };
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ActivityEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iActivityApi.Update(id, request);
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
            var member = await _iActivityApi.GetById(id);
            var request = new ActivityDeleteRequest()
            {
                Id = member.Id,
            };
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ActivityDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iActivityApi.Delete(request.Id);
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
