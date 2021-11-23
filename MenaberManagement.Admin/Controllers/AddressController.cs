 using MemberManagement.ViewModels.AddressViewModels;
using MenaberManagement.Admin.Models;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IAddressApiClient _iAddressApiClient;
        private readonly IConfiguration _configuration;
        private readonly Tinh tinh;

        public AddressController(IAddressApiClient iAddressApiClient,
            IConfiguration configuration, IOptions<Tinh> optionsTinh)
        {
            _configuration = configuration;
            _iAddressApiClient = iAddressApiClient;
            tinh = optionsTinh.Value;
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
            var request = new AddressCreatRequest();
          
            request.ProvinceJsons = Country_Bind();
            var a = State_Bind("14");
                return View(request);
        }
       
        public ActionResult Action()
        {
            Country_Bind();
            return View();

        }
        public List<ProvinceJson> Country_Bind()
        {
          
            var json = System.IO.File.ReadAllText(@"wwwroot/dist/tinh_tp.json");
            var files = JsonConvert.DeserializeObject<Dictionary<string, ProvinceJson>>(json);
            var listP = new List<ProvinceJson>();
            foreach (var b in files)
            {
                ProvinceJson p = b.Value;
                listP.Add(p);
            }

           return listP;
        }
        public ActionResult GetAll(string level1_id)
        {
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"wwwroot/Json/jsconfig.json");
            var books = JsonConvert.DeserializeObject<Tinh>(json);


            return View("Create");

        }
        public JsonResult State_Bind(string parent_code)
        {
            string[] filePaths = Directory.GetFiles(@"wwwroot/dist/quan-huyen/", "*.json");
            var a = filePaths;
            string result;
            List<SelectListItem> coutrylist = new List<SelectListItem>();

            foreach (var file in filePaths)
            {
                result = Path.GetFileNameWithoutExtension(file);
                if (parent_code.Contains(result))
                {
                    var json = System.IO.File.ReadAllText($@"wwwroot/dist/quan-huyen/{result}.json");
                    var files = JsonConvert.DeserializeObject<Dictionary<string, DistrictJon>>(json);
                    var listP = new List<DistrictJon>();

                    foreach (var b in files)
                    {
                        DistrictJon p = b.Value;
                        listP.Add(p);
                        var c = new SelectListItem()
                        {
                           Text = p.name,
                           Value = p.code  
                        };
                    }
                    continue;
                }
            }

           
            return Json(coutrylist);

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
