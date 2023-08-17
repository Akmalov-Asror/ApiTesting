using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public CourseRepository(AppDbContext.AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Course?>> GetCourseAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course?> GetCourseByIdAsync(Guid id)
    {
        return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Course> CreateCourseAsync(CourseDto courseDto)
    {
        var course = courseDto.Adapt<Course>();
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task<Course?> UpdateCourseAsync(CourseDto courseDto)
    {
        var findCourse = await _context.Courses.FirstOrDefaultAsync(u => u.Id == courseDto.Id);

        if (findCourse == null) return findCourse;

        findCourse.Title = courseDto.Title;
        findCourse.Description = courseDto.Description;
        findCourse.Price = courseDto.Price;
        findCourse.ImgUrl = courseDto.ImgUrl;
        findCourse.DescriptionCourseId = courseDto.DescriptionCourseId;

        await _context.SaveChangesAsync();

        return findCourse;
    }

    public async Task DeleteCourseAsync(Guid id)
    {
        var findCourse = await _context.Courses.FirstOrDefaultAsync(u => u.Id == id);
        if (findCourse != null) _context.Courses.Remove(findCourse);
        await _context.SaveChangesAsync();
    }
}