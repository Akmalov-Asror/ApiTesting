using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = postgress.Entities.Task;

namespace postgress.Controller; 

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public TaskController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddTask(TaskDto taskDto)
    {
        if (taskDto is null)
            return BadRequest("please check the request again");
        return Ok(await _taskRepository.CreateTaskAsync(taskDto));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Contact))]
    public async Task<IActionResult> GetTaskById(Guid id) => Ok(await _taskRepository.GetTaskByIdAsync(id));

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Task>))]
    public async Task<ActionResult> GetAllTasks() => Ok(await _taskRepository.GetTaskAllAsync() ?? new List<Task?>());

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTask(string fullName, TaskDto taskDto)
    {
        var teacher = await _taskRepository.UpdateTaskAsync(fullName, taskDto);
        if (teacher is null)
            return NotFound("This Teacher is not Defined");
        return Ok(teacher);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Teacher>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        await _taskRepository.DeleteTaskAsync(id);
        return Ok("User is Deleted");
    }

}