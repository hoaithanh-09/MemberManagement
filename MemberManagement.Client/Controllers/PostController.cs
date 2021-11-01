using MemberManagement.Client.Models;
using MenaberManagement.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newspaper.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Client.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostApi _iPostApi;
        private readonly IConfiguration _configuration;
        private readonly IImageApi _iImageApi;
        private readonly IAuthorApi _iAuthorApi;
        private readonly ITopicApi _iTopicApi;
        public PostController(
            IPostApi iPostApi,
            IConfiguration configuration,
            IImageApi iImageApi,
            IAuthorApi iAuthorApi,
            ITopicApi iTopicApi
            
            )
        {
            _iPostApi = iPostApi;
            _configuration = configuration;
            _iImageApi = iImageApi;
            _iAuthorApi = iAuthorApi;
            _iTopicApi = iTopicApi;
        }
        
        
        public async Task<IActionResult> Details(int id)
        {
            var post = await _iPostApi.GetById(id);
            return View(new PostDetailViewModel()
            {
                Post = post
            }) ;
        }

        public async Task<IActionResult> Topic(int id, int page = 1)
        {
            var posts = await _iPostApi.GetPostPaging(new GetPostPagingRequest()
            {
                PageIndex = page,
                PageSize = 10
            });
            return View(new PostInTopicVM()
            {
                Topics = await _iTopicApi.GetById(id),
                 Posts= posts
            }); 
        }


    }
}
