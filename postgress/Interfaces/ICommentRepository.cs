using System.Security.Claims;
using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment?>> GetCommentAllAsync();
    Task<Comment> WriteCommentAsync(ClaimsPrincipal claims, Guid  taskId, CommentDto commentDto);
    Task<Comment?> UpdateCommentAsync(ClaimsPrincipal claims, Guid taskId, CommentDto commentDto);
    Task DeleteCommentAsync(Guid id);
}