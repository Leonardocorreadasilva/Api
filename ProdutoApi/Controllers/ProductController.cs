using Api.Domain.Entities;
using Api.Domain.Interface.Service.Product;
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
    public class ProductController : ControllerBase
    {
        private string versao = "v1";
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {

            _productService = productService;

        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                return Ok(null); //await _productService.Get(id));
            }

            catch (ArgumentException ex) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("v1/GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(null); //await _productService.GetAll());
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
                return null; //Ok (await _productService.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("v1/Create")]
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromServices]  IProductService _productService, ProductRequest product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try 
            {
                var result = await _productService.Create(product);
                if (result != null)
                {
                    return Ok(Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result));
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
