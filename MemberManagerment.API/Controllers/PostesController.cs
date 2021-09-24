using MemberManagement.Services.Posts;
using MemberManagement.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.API.Controllers
{
    public class PostesController : Controller
    {
        private readonly IPostSV _postSv;
        public PostesController(IPostSV postSv)
        {
            _postSv = postSv;
        }
        [HttpGet("GetALl")]
        public async Task<IActionResult> GetAll()
        {
            var contact = await _postSv.getAll();
            return Ok(contact);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] PostCreatRequest request)
        {
            var contact = await _postSv.Create(request);
            return Ok(contact);
        }
    }
}
