using MemberManagement.ViewModels.Common;
using MemberManagement.ViewModels.FundViewModels;
using MenaberManagement.Admin.Models;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class FundsController : BaseController
    {
        private readonly IFundApi _iFundApi;
        private readonly IConfiguration _configuration;
        private readonly IGroupApiClient _iGroupApiClient;
        public FundsController(
            IGroupApiClient iGroupApiClient,
            IConfiguration configuration,
            IFundApi iFundApi
            )
        {
            _iGroupApiClient = iGroupApiClient;
            _configuration = configuration;
            _iFundApi = iFundApi;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            if (!ModelState.IsValid)
                return View();

            var request = new GetFundPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var data = await _iFundApi.GetFundPaging(request);
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


            var members = await _iGroupApiClient.GetAll();
            var activityCreatRequest = new FundCreateRequest();

            activityCreatRequest.Groups = members;
            return View(activityCreatRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FundCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var members = await _iGroupApiClient.GetAll();
            request.Groups = members;

            var result = await _iFundApi.Create(request);

            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }
            if (result.IsSuccessed)
            {
                TempData["result"] = result.ResultObj;
                return RedirectToAction("Index", "Funds");
            }
            return View(request);
        }
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iFundApi.GetById(id);
            return View(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var activity = await _iFundApi.GetById(id);
            var request = new FundEditRequest()
            {
                Name = activity.Name,
                TotalFund = activity.TotalFund,
                Description = activity.Description,
                CreatedDate = activity.CreatedDate,
            };
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FundEditRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iFundApi.Update(id, request);
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
            var member = await _iFundApi.GetById(id);
            var request = new FundDeleteRequest()
            {
                Id = member.Id,
            };
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, FundDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _iFundApi.Delete(request.Id);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> ListAction(int id)
        {
            var roleAssignRequest = await ListActionFund(id);

            return View(roleAssignRequest.Items);
        }

        private async Task<PagedResult<ListAction>> ListActionFund(int id)
        {
            var request = new GetFundPagingRequest()
            {
                Keyword = "",
                PageIndex = 1,
                PageSize = 10,
            };
            var data = await _iFundApi.ListAction(id, request);

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return data;
        }
    }
}
