﻿using MemberManagement.Services.Contacts;
using MemberManagement.ViewModels.ContactViewModels;
using MemberManagement.ViewModels.ContractMemberViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MemberManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactSV _contactSV;
        public ContactsController(IContactSV contactSV)
        {
            _contactSV = contactSV;
        }
        [HttpGet("GetALl")]
        public async Task<IActionResult> GetAll()
        {
            var contact = await _contactSV.GetAll();
            return Ok(contact);
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] ContactCreateRequest request)
        {
            var contact = await _contactSV.Create(request);
            return Ok(contact);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var contact = await _contactSV.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactSV.GetById(id);
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ContactEditRequest request)
        {
            try
            {
                var member = await _contactSV.Update(id, request);
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaing([FromQuery] GetContactPagingRequest request)
        {
            var family = await _contactSV.GetPagedResult(request);
            return Ok(family);
        }
        [HttpGet("ListMember")]
        public async Task<IActionResult> ListMember(int idContract,[FromQuery] GetContactPagingRequest request)
        {
            var family = await _contactSV.ListMember(idContract,request);
            return Ok(family);
        }


        [HttpDelete("RemoveMember")]
        public async Task<IActionResult> RomoveMember(int idContract, [FromBody] int idMember)
        {
            var family = await _contactSV.RomoveMember(idContract, idMember);
            return Ok(family);
        }


        [HttpPost("AddMember")]
        public async Task<IActionResult> AddMember( int idContract, [FromBody] ContactMemberCreateRequest idMember)
        {
            var family = await _contactSV.AddMember(idContract,idMember);
            return Ok(family);
        }
    }
}
