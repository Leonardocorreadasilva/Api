using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;
using System.Net;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {

            _userService = userService;

        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (ArgumentException ex) 
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _userService.Get(id));
            }

            catch (ArgumentException ex) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                return Ok (await _userService.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromServices] IUserService userService, [FromBody] UserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                var result = await userService.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
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

        [HttpPut]
        public async Task<ActionResult> Put([FromServices] IUserService userService, [FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await userService.Put(user);
                if (result != null)
                {
                    return Ok(result);
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
