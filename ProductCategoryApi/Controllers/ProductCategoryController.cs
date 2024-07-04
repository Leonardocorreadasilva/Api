using Api.Domain.Entities;
using Api.Domain.Interface.Service.Product;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProductCategoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategory _productCategoryService;

        public ProductCategoryController(IProductCategory productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet("{id}/v1/GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var category = await _productCategoryService.Get(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
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
                var categories = await _productCategoryService.GetAll();
                return Ok(categories);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("v1/Post")]
        public async Task<ActionResult> Post(ProductCategoryEntity category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdCategory = await _productCategoryService.Post(category);
                if (createdCategory != null)
                {
                    return CreatedAtAction(nameof(Get), new { id = createdCategory.Id }, createdCategory);
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
        public async Task<IActionResult> Put(ProductCategoryEntity category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _productCategoryService.Put(category);
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

        [HttpDelete("{id}/v1/Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var success = await _productCategoryService.Delete(id);
                if (!success)
                {
                    return NotFound();
                }
                return Ok(success);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{categoryId}/products")]
        public async Task<ActionResult> GetProductsByCategory(Guid categoryId)
        {
            try
            {
                var products = await _productCategoryService.GetProductsByCategory(categoryId);
                return Ok(products);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
