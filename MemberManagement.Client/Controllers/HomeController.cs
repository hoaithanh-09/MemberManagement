using MemberManagement.Client.Models;
using MenaberManagement.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostApi _iPostApi;

        public HomeController(ILogger<HomeController> logger, IPostApi iPostApi)
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

        /*public async Task<IActionResult> List_Activities()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var viewModel = new HomeViewModel
            {
                Slides = await _slideApiClient.GetAll(),
                FeaturedProducts = await _productApiClient.GetFeaturedProducts(culture, SystemConstants.ProductSettings.NumberOfFeaturedProducts),
                LatestProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts),
            };
        }*/




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
