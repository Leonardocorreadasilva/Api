using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ReviewApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("v1/GetWithId/{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                var review = await _reviewService.Get(id);
                if (review == null)
                {
                    return NotFound();
                }
                return Ok(review);
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
                var reviews = await _reviewService.GetAll();
                return Ok(reviews);
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
                var result = await _reviewService.Delete(id);
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
        public async Task<ActionResult> Post([FromBody] ReviewRequest review)
        {
            try
            {
                var createdReview = await _reviewService.Post(review);
                return CreatedAtAction(nameof(Get), new { id = createdReview.Id }, createdReview);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("v1/Put")]
        public async Task<ActionResult> Put([FromBody] ReviewRequest review)
            {
            try
            {
                var updatedReview = await _reviewService.Put(review);
                return Ok(updatedReview);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
