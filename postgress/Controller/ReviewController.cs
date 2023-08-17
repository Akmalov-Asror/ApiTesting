using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewController(IReviewRepository reviewRepository) => _reviewRepository = reviewRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllReview() => Ok(await _reviewRepository.GetAllAsync());
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdReview(Guid id) => Ok(await _reviewRepository.GetAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateReview(ReviewDto reviewDto) => Ok(await _reviewRepository.CreateAsync(reviewDto));

    [HttpPut]
    public async Task<IActionResult> UpdateReview(Guid id, ReviewDto reviewDto) => Ok(await _reviewRepository.UpdateAsync(id, reviewDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteReview(Guid id)
    {
        await _reviewRepository.DeleteAsync(id);
        return Ok("Review is deleted");
    }
}