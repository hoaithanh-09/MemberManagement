﻿using System;
using System.Threading.Tasks;
using MemberManagement.Services.Posts;
using MemberManagement.ViewModels.ImageInPostViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newspaper.ViewModels.PostViewModels;

namespace MemberManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostsController: ControllerBase
    {
        private readonly IPostSV _postSV;
        //dd
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
        [HttpPost("CreatePost")]
        public async Task<ActionResult> Create([FromBody] PostCreateRequest request)
        {
            var post = await _postSV.Create(request);
            return Ok(post);
        }
        [HttpDelete("DeletePost/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var post = await _postSV.Delete(id);
            return Ok();
        }

        [HttpGet("GetByIdPost/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postSV.GetById(id);
            return Ok(post);
        }

        [HttpPut("UpdatePosst/{id}")]
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
        [HttpPost("Add ImageInPost")]
        public async Task<ActionResult> AddImage([FromRoute] int id,[FromBody] ImageInPostCreateRequest request)
        {
            var post = await _postSV.AddImage(id,request);
            return Ok(post);
        }

    }
    
}

