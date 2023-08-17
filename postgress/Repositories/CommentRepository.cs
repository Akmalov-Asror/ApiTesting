using System.Security.Claims;
using System.Xml.Linq;
using JFA.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
[Scoped]
public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public CommentRepository(AppDbContext.AppDbContext context) => _context = context;

    public async Task<List<Comment?>> GetCommentAllAsync() => await _context.Comments.ToListAsync() ?? new List<Comment>();

    public async Task<Comment> WriteCommentAsync(ClaimsPrincipal claims, Guid taskId, CommentDto commentDto)
    {
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var comment = await _context.Comments.FindAsync(userId);
        if (comment == null)
        {
            comment = new Comment()
            {
                UserId = userId,
                Desc = commentDto.Desc,
                DocumentPath = commentDto.DocumentPath,
                TaskId = taskId,
            };
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        await _context.AddAsync(comment);
        await _context.SaveChangesAsync();

        return comment;
    }

    public async Task<Comment?> UpdateCommentAsync(ClaimsPrincipal claims, Guid taskId, CommentDto commentDto)
    {
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var comment = await _context.Comments.FindAsync(userId);

        if (comment == null)
        {
            return comment;
        }

        comment.Desc = commentDto.Desc;
        comment.DocumentPath = commentDto.DocumentPath;
        comment.TaskId = taskId;

        await _context.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;

    }

    public async Task DeleteCommentAsync(Guid id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(i => i.Id == id);
        if (comment != null) _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();

    }
}