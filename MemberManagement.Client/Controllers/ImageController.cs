using MemberManagement.ViewModels.ImageViewModels;
using MenaberManagement.Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class ImageController:BaseController
    {
        private readonly IImageApi _iImageApi;
        private readonly IConfiguration _configuration;


        public ImageController(IImageApi iImageApi,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _iImageApi = iImageApi;
        }
        
        // GET: FamiliesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iImageApi.GetById(id);
            return View(result);
        }

        // GET: FamiliesController/Create
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var author = await _iImageApi.GetAll();
            return Ok(author);
        }
    }
}
