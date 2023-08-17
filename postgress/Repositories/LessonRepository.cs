using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public LessonRepository(AppDbContext.AppDbContext context) => _context = context;

    public async Task<Lesson> GetLessonAsync(Guid id) => await _context.Lessons.FirstOrDefaultAsync(u => u.Id == id);
     
    public async Task<List<Lesson>> GetLessonAllAsync() => await _context.Lessons.ToListAsync();

    public async Task<Lesson> AddLessonAsync(LessonDto lessonDto)
    {
        var lesson = lessonDto.Adapt<Lesson>();
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();
        return lesson;
    }

    public async Task<Lesson> UpdateLessonAsync(Guid id, LessonDto lessonDto)
    {
        var findLesson = await _context.Lessons.FirstOrDefaultAsync(o => o.Id == id);

        findLesson.Title = lessonDto.Title;
        findLesson.VideoUrl = lessonDto.VideoUrl;
        findLesson.Info = lessonDto.Info;

        await _context.SaveChangesAsync();
        return findLesson;
    }

    public async Task DeleteLessonAsync(Guid id)
    {
        var lesson = await _context.Lessons.FirstOrDefaultAsync(i => i.Id == id);
        if (lesson != null) _context.Lessons.Remove(lesson);
        await _context.SaveChangesAsync();
    }
}