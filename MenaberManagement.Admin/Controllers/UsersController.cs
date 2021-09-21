using MemberManagement.ViewModels.UserViewModels;
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
    public class UsersController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        public UsersController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 1)
        {
            var sessions = HttpContext.Session.GetString("JWT");
            var request = new GetUserPagingRequest()
            {
                BearerToken = sessions,
                KeyWord = keyword,

                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _userApiClient.GetUserPaging(request);
            return View(data.ResultObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        //public async Task<IActionResult> Create(RegisterRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View();
        //    var result = await _userApiClient.RegisterUser(request);
        //    if (!result.IsSuccessed)
        //    {
        //        ModelState.AddModelError("", result.Message);
        //        return View(request);
        //    }
        //    if (result.IsSuccessed)
        //    {
        //        return RedirectToAction("Index", "Users");
        //    }
        //    return View(request);
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Update(string id)
        //{
        //    var result = await _userApiClient.GetById(id);
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    if (result.IsSuccessed)
        //    {
        //        var user = result.ResultObj;
        //        var updateRequse = new UserUpdateRequest()
        //        {
        //            UserName = user.UserName,
        //            Email = user.Email,
        //            PhoneNumber = user.PhoneNumber,
        //        };
        //        return View(updateRequse);
        //    }
        //    return View("Error", "Home");
        //}
        //[HttpPut]
        //public async Task<IActionResult> Update(UserUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View("sadas");

        //    return View("asdas");
        //}
    }
}
