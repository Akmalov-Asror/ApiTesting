using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Repositories;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepository;

    public TeachersController(ITeacherRepository teacherRepository) => _teacherRepository = teacherRepository;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddTeacher(TeacherDto teacherDto)
    {
        if (teacherDto is null)
            return BadRequest("please check the request again");
        return Ok(await _teacherRepository.CreateTeacherAsync(teacherDto));
    }
   
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Teacher>))]
    public async Task<ActionResult> GetAllTeachers() => Ok(await _teacherRepository.GetTeacherAllAsync() ?? new List<Teacher?>());

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTeacher(string fullName, TeacherDto teacherDto)
    {
        var teacher = await _teacherRepository.UpdateTeacherAsync(fullName, teacherDto);
        if (teacher is null)
            return NotFound("This Teacher is not Defined");
        return Ok(teacher);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Teacher>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteTeacher(Guid id)
    {
        await _teacherRepository.DeleteTeacherAsync(id);
        return Ok("User is Deleted");
    }

}