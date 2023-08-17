using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Interfaces;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ResultController : ControllerBase
{
    private readonly IResultRepository _resultRepository;
    public ResultController(IResultRepository resultRepository) => _resultRepository = resultRepository;

    [HttpGet]
    public async Task<IActionResult> GetComments() => Ok(await _resultRepository.GetResultAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(Guid id) => Ok(await _resultRepository.GetResultByIdAsync(id));

    [HttpPost]

    public async Task<IActionResult> WriteCommentAsync(Guid taskId,  ResultDto resultDto) => Ok(await _resultRepository.AddResultAsync(User, taskId, resultDto));

    [HttpPut]
    public async Task<IActionResult> UpdateCommentAsync(Guid taskId, ResultDto resultDto) => Ok(await _resultRepository.UpdateResultAsync(User, taskId, resultDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(Guid id)
    {
        await _resultRepository.GetResultAllAsync();
        return Ok("User is Deleted");
    }
}