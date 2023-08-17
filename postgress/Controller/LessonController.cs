using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Interfaces;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class LessonController : ControllerBase
{
    private readonly ILessonRepository _lessonRepository;

    public LessonController(ILessonRepository lessonRepository) => _lessonRepository = lessonRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllLesson() => Ok(await _lessonRepository.GetLessonAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLessonById(Guid id) => Ok(await _lessonRepository.GetLessonAsync(id));

    [HttpPost]
    public async Task<IActionResult> AddLessonAsync(LessonDto lessonDto) => Ok(await _lessonRepository.AddLessonAsync(lessonDto));

    [HttpPut]
    public async Task<IActionResult> UpdateLesson(Guid id, LessonDto lessonDto) => Ok(await _lessonRepository.UpdateLessonAsync(id, lessonDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteLessonById(Guid id)
    {
        await _lessonRepository.DeleteLessonAsync(id);
        return Ok("Lesson deleted");
    }
}