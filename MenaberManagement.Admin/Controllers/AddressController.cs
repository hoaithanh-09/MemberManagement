using MemberManagement.ViewModels.AddressViewModels;
using MenaberManagement.Admin.Models;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> test()
        {
            var data = await _iAddressApiClient.GetProvince();
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
            ViewBag.Province = new SelectList("Id","Name");
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
        public async Task<ActionResult> Test1()
        {
            List<SelectListItem> provinceeNames = new List<SelectListItem>();
            CascadingModel model = new CascadingModel();
            var listProvince = await _iAddressApiClient.GetProvince();
            //foreach (var country in listProvince)
            //{
            //    model.Provinces.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
            //}
            listProvince.ForEach(x =>
            {
                provinceeNames.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            });
            model.Provinces = provinceeNames;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> GetDistrict(string idProvince)
        {
            int statId;
            List<SelectListItem> districtNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(idProvince))
            {
                statId = Convert.ToInt32(idProvince);
                List<DistrictVM> districts =await _iAddressApiClient.GetDistrict(statId);
                districts.ForEach(x =>
                {
                    districtNames.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
                });
            }
            return Json(districtNames);
        }

    

        //[HttpPost]
        //public async Task<ActionResult> Test1(int? ProvinceId, int? DistrictId, int? WardId)
        //{
        //    CascadingModel model = new CascadingModel();
        //    var listProvince = await _iAddressApiClient.GetProvince();
        //    foreach (var country in listProvince)
        //    {
        //        model.Provinces.Add(new SelectListItem { Text = country.Name, Value = country.Id.ToString() });
        //    }
        //    if (ProvinceId.HasValue)
        //    {
        //        var district = await _iAddressApiClient.GetDistrict(ProvinceId.Value);
        //        foreach (var state in district)
        //        {
        //            model.Districts.Add(new SelectListItem { Text = state.Name, Value = state.Id.ToString() });
        //        }
        //    }
        //    if (DistrictId.HasValue)
        //    {
        //        var wards = await _iAddressApiClient.GetWard(DistrictId.Value);
        //        foreach (var ward in wards)
        //        {
        //            model.Wards.Add(new SelectListItem { Text = ward.Name, Value = ward.Id.ToString() });
        //        }
        //    }

        //    return View(model);
        //}
    }
}
