using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Interfaces;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HomeworkController : ControllerBase
{
    private readonly IHomeworkRepository _homeworkRepository;

    public HomeworkController(IHomeworkRepository homeworkRepository) => _homeworkRepository = homeworkRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllHomeworks() => Ok(await _homeworkRepository.GetHomeworkAllAsync());

    [HttpPost]
    public async Task<IActionResult> AddHomeWork(Guid taskId, HomeworkDto homeworkDto) => Ok(await _homeworkRepository.CreateHomeworkAsync(User, taskId, homeworkDto));

    [HttpPut]
    public async Task<IActionResult> UpdateHomework(string name, Guid taskId, HomeworkDto homeworkDto) => Ok(await _homeworkRepository.UpdateHomeworkAsync(User, taskId, homeworkDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteHomework(Guid id)
    {
        await _homeworkRepository.DeleteHomeworkAsync(id);
        return Ok("Homework is deleted");
    }
}