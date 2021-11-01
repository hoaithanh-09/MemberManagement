using MemberManagement.ViewModels.AuthorViewModels;
using MenaberManagement.Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenaberManagement.Client.Controllers
{
    public class AuthorController :Controller
    {
        private readonly IAuthorApi _authorApi;
        private readonly IConfiguration _configuration;


        public AuthorController(IAuthorApi authorApi,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _authorApi = authorApi;
        }
        

        // GET: FamiliesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _authorApi.GetById(id);
            return View(result);
        }

        // GET: FamiliesController/Create

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var author = await _authorApi.GetAll();
            return Ok(author);
        }

    }
}
