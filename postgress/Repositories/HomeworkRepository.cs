using System.Security.Claims;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;

public class HomeworkRepository : IHomeworkRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public HomeworkRepository(AppDbContext.AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Homework?>> GetHomeworkAllAsync()
    {
        return await _context.Homework.ToListAsync();
    }

    public async Task<Homework> CreateHomeworkAsync(ClaimsPrincipal claims, Guid taskId,HomeworkDto homeworkDto)
    {
        var homework = homeworkDto.Adapt<Homework>();

        await _context.Homework.AddAsync(homework);
        await _context.SaveChangesAsync();

        return homework;
    }

    public async Task<Homework?> UpdateHomeworkAsync(string name,Guid taskId,HomeworkDto homeworkDto)
    {
        var findHomework = await _context.Homework.FirstOrDefaultAsync(u => u.Name == name);

        if (findHomework == null) return findHomework;

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