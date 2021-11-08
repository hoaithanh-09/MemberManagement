using MemberManagement.ViewModels.PostViewModels;
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
    public class PostClientController : Controller
    {
        private readonly IPostApiClient _iPostApi;
        private readonly IConfiguration _configuration;
        private readonly IImageApi _iImageApi;
        private readonly ITopicApi _iTopicApi;
        public PostClientController(
            IPostApiClient iPostApi,
            IConfiguration configuration,
            IImageApi iImageApi,
            ITopicApi iTopicApi
            
            )
        {
            _iPostApi = iPostApi;
            _configuration = configuration;
            _iImageApi = iImageApi;
            _iTopicApi = iTopicApi;
        }
        public async Task<IActionResult> Index()
        {
            var a = new GetPostPagingRequest()
            {
                PageIndex = 1,
                PageSize = 10,
            };
            var post = await _iPostApi.GetPostPaging(a);


            return View(post.Items);
        }

        public async Task<IActionResult> Test()
        {
            var a = new GetPostPagingRequest()
            {
                PageIndex = 1,
                PageSize = 10,
            };
            var post = await _iPostApi.GetPostPaging(a);
            //var listpost = post.Items;
            //var l = new List<PostVM>();
            //foreach (var pos in listpost)
            //{
            //    pos.PathFile = "~" + pos.PathFile;
            //    l.Add(pos);
            //}
            return View(post.Items);
        }



    }
}
