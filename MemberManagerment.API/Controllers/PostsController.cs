using System;
using System.Threading.Tasks;
using MemberManagement.Services.Posts;
using MemberManagement.ViewModels.ImageInPostViewModels;
using MemberManagement.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostsController: ControllerBase
    {
        private readonly IPostSV _postSV;
        public PostsController(IPostSV postSV)
        {
            _postSV = postSV;
        }
        [HttpGet("GetALlPost")]
        public async Task<IActionResult> GetAll()
        {
            var post = await _postSV.GetAll();
            return Ok(post);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Create([FromForm] PostCreateRequest request)
        {
            var post = await _postSV.Create(request);
            return Ok(post);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var post = await _postSV.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postSV.GetById(id);
            return Ok(post);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PostEditRequest request)
        {
            try
            {
                var post = await _postSV.Update(id, request);
                return Ok(post);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("pagingPost")]
        public async Task<IActionResult> GetPaing([FromQuery] GetPostPagingRequest request)
        {
            var post = await _postSV.GetPagedResult(request);
            return Ok(post);
        }
        //add ImageInPost
        [HttpPost("AddImageInPost")]
        public async Task<ActionResult> AddImage([FromRoute] int id,[FromBody] ImageInPostCreateRequest request)
        {
            var post = await _postSV.AddImage(id,request);
            return Ok(post);
        }
    }
    
}

