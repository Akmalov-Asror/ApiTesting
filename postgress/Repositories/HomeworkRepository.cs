using System.Security.Claims;
using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
[Scoped]
public class HomeworkRepository : IHomeworkRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public HomeworkRepository(AppDbContext.AppDbContext context) => _context = context;

    public async Task<List<Homework?>> GetHomeworkAllAsync()
    {
        return await _context.Homework.ToListAsync();
    }

    public async Task<Homework> CreateHomeworkAsync(ClaimsPrincipal claims, Guid taskId,HomeworkDto homeworkDto)
    {
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var homework = new Homework()
        {
            ImgUrl = homeworkDto.ImgUrl,
            Name = homeworkDto.Name,
            TaskId = taskId,
            UserId = userId
        };

        await _context.Homework.AddAsync(homework);
        await _context.SaveChangesAsync();

        return homework;
    }

    public async Task<Homework?> UpdateHomeworkAsync(ClaimsPrincipal claims, Guid taskId,HomeworkDto homeworkDto)
    {
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var findHomework = await _context.Homework.FirstOrDefaultAsync(u => u.Name == homeworkDto.Name);

        if (findHomework == null) return findHomework;
        findHomework.UserId = userId;
        findHomework.Name = homeworkDto.Name;
        findHomework.ImgUrl = homeworkDto.ImgUrl;
        findHomework.TaskId = taskId;

        await _context.SaveChangesAsync();

        return findHomework;
    }

    public async Task DeleteHomeworkAsync(Guid id)
    {
        var homework = await _context.Homework.FirstOrDefaultAsync(i => i.Id == id);
        if (homework != null) _context.Homework.Remove(homework);
        await _context.SaveChangesAsync();
    }
}