using MemberManagement.Data.Entities;
using MemberManagement.Services.Addresses;
using MemberManagement.ViewModels.AddressViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressSV _address;
        public AddressesController(IAddressSV address)
        {
            _address = address;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var group = await _address.GetAll();
            return Ok(group);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetPaing([FromQuery] GetAddressPagingRequest request)
        {
            var family = await _address.GetPagedResult(request);
            return Ok(family);
        }

        [HttpPost("Creat")]
        public async Task<ActionResult> Create([FromBody] AddressCreatRequest request)
        {
            var family = await _address.Create(request);
            return Ok(family);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete( int id)
        {
            var family = await _address.Delete(id);

            return Ok(family);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> getID( int id)

        {
            var family = await _address.GetById(id);
            return Ok(family);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] AddressEditRequest request)
        {
            try
            {
                var address = await _address.Update(id, request);
                return Ok(address);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("ProvinceDetails")]
        public async Task< List<ProvinceVM>> ProvinceDetails()
        {
            List<ProvinceVM> countryDetail = new List<ProvinceVM>();
                countryDetail = await _address.LoadProvince();
            return countryDetail;
        }

        [HttpGet]
        [Route("DistrictDetails")]
        public async Task<List<DistrictVM>> DistrictDetails(int id)
        {
            List<DistrictVM> countryDetail = new List<DistrictVM>();
            countryDetail = await _address.LoadDistrict(id);
            return countryDetail;
        }

        [HttpGet]
        [Route("WardDetails")]
        public async Task<List<WardVM>> WardDetails(int id)
        {
            List<WardVM> countryDetail = new List<WardVM>();
            countryDetail = await _address.LoadWard(id);
            return countryDetail;
        }

    }
}
