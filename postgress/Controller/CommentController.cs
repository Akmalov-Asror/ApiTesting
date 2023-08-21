using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Filters;
using postgress.Interfaces;
using postgress.Repositories;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    public CommentController(ICommentRepository commentRepository) => _commentRepository = commentRepository;

    [HttpGet]
    public async Task<IActionResult> GetComments() => Ok(await _commentRepository.GetCommentAllAsync());

    [HttpPost]
    [IdValidation]
    public async Task<IActionResult> WriteCommentAsync(Guid taskId, CommentDto commentDto) => Ok(await _commentRepository.WriteCommentAsync(User, taskId, commentDto));

    [HttpPut]
    [IdValidation]
    public async Task<IActionResult> UpdateCommentAsync(Guid taskId, CommentDto commentDto) => Ok(await _commentRepository.UpdateCommentAsync(User, taskId, commentDto));

    [HttpDelete]
    public async Task<IActionResult> DeleteContact(Guid id)
    {
        await _commentRepository.DeleteCommentAsync(id);
        return Ok("User is Deleted");
    }
}