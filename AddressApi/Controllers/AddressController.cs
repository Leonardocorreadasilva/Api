using Api.Domain.Entities;
using Api.Domain.Interface.Service.Address;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("{id}/v1/GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var address = await _addressService.Get(id);
                if (address == null)
                {
                    return NotFound();
                }
                return Ok(address);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var addresses = await _addressService.GetAll();
                return Ok(addresses);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}/v1/Delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _addressService.Delete(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/Post")]
        public async Task<ActionResult> Post([FromBody] AddressRequest addressRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var address = await _addressService.Post(addressRequest);
                if (address != null)
                {
                    return CreatedAtAction(nameof(Get), new { id = address.Id }, address);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("v1/Put")]
        public async Task<ActionResult> Put([FromBody] AddressRequest addressRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var address = await _addressService.Put(addressRequest);
                if (address != null)
                {
                    return Ok(address);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
