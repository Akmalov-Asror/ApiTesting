using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Interfaces;
using postgress.Repositories;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class DescriptionCourseController : ControllerBase
{
    private readonly IDescriptionCourse _descriptionCourse;

    public DescriptionCourseController(IDescriptionCourse descriptionCourse) => _descriptionCourse = descriptionCourse;

    [HttpGet]
    public async Task<IActionResult> GetDescriptionAll() => Ok(await _descriptionCourse.GetDescriptionAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDescriptionById(Guid id) => Ok(await _descriptionCourse.GetDescriptionByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> WriteDescriptionCourse(DescriptionCourseDto descriptionCourseDto) => Ok(await _descriptionCourse.CreateDescription(descriptionCourseDto));

    [HttpPut]
    public async Task<IActionResult> UpdateDescriptionCourse(Guid id, DescriptionCourseDto descriptionCourseDto) => Ok(await _descriptionCourse.UpdateDescriptionAsync(id, descriptionCourseDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteDescription(Guid id)
    {
        await _descriptionCourse.DeleteDescriptionAsync(id);
        return Ok("Description is deleted");
    }
}