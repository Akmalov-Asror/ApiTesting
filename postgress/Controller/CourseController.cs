using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Interfaces;
using postgress.Repositories;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository) => _courseRepository = courseRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllComments() => Ok(await _courseRepository.GetCourseAllAsync());
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(Guid id) => Ok(await _courseRepository.GetCourseByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> WriteCommentAsync(CourseDto courseDto) => Ok(await _courseRepository.CreateCourseAsync(courseDto));

    [HttpPut]
    public async Task<IActionResult> UpdateCommentAsync(CourseDto courseDto) => Ok(await _courseRepository.UpdateCourseAsync(courseDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(Guid id)
    {
        await _courseRepository.DeleteCourseAsync(id);
        return Ok("User is Deleted");
    }
}