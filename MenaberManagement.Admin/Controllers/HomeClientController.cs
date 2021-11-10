
using MenaberManagement.Admin.Models;
using MenaberManagement.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Admin.Controllers
{
    
    public class HomeClientController : Controller
    {
        private readonly ILogger<HomeClientController> _logger;
        private readonly IPostApiClient _iPostApi;

        public HomeClientController(ILogger<HomeClientController> logger, IPostApiClient iPostApi)
        {
            _logger = logger;
            _iPostApi = iPostApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List_Intro()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Introduction()
        {
            return View();
        }
        public IActionResult Regulation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
