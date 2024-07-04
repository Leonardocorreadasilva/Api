using Api.Domain.Entities;
using Api.Domain.Interface.Service.Product;
using Microsoft.AspNetCore.Mvc;
using Shared.Request;
using System.Net;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IItemsService _itemsService;

        public ProductController(IProductService productService, IItemsService itemsService)
        {
            _productService = productService;
            _itemsService = itemsService;
        }

        [HttpGet("v1/GetWithId/{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var product = await _productService.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/Create")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductRequest product)
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
                    return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
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

        [HttpGet("v1/GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAll();
                return Ok(products);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("v1/Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _productService.Delete(id);
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

        

        [HttpPut("v1/Put")]
        public async Task<ActionResult> Put([FromBody] ProductRequest product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _productService.Edit(product);
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


        [HttpPost("v1/Purchase")]
        public async Task<ActionResult> Purchase(ItemsRequest Items)
        {
            try
            {
                var success = await _itemsService.Purchase(Items);
                return Ok(success); // Corrigido aqui
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/Purchase/GetAll")]
        public async Task<ActionResult> GetPurchase()
        {
            try
            {
                var success = await _itemsService.GetAll();
                return Ok(success); // Corrigido aqui
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("v1/Purchase/GetWithId/{id}")]
        public async Task<ActionResult> GetPurchaseWithId(Guid id)
        {
            try
            {
                var success = await _itemsService.Get(id);
                return Ok(success); // Corrigido aqui
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
