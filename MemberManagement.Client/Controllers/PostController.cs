using MenaberManagement.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newspaper.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostApi _iPostApi;
        private readonly IConfiguration _configuration;
        private readonly IImageApi _iImageApi;
        private readonly IAuthorApi _iAuthorApi;
        public PostController(
            IPostApi iPostApi,
            IConfiguration configuration,
            IImageApi iImageApi,
            IAuthorApi iAuthorApi
            )
        {
            _iPostApi = iPostApi;
            _configuration = configuration;
            _iImageApi = iImageApi;
            _iAuthorApi = iAuthorApi;
        }
        
        
        public async Task<IActionResult> Details(int id)
        {
            var result = await _iPostApi.GetById(id);
            return View(result);
        }

        public async Task<IActionResult> GetAll()
        {
            var post = await _iPostApi.GetAll();
            return Ok(post);
        }


    }
}
