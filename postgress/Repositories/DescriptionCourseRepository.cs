using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Interfaces;

namespace postgress.Repositories;

public class DescriptionCourse : IDescriptionCourse
{
    private readonly AppDbContext.AppDbContext _context;

    public DescriptionCourse(AppDbContext.AppDbContext context) => _context = context;

    public async Task<List<Entities.DescriptionCourse>> GetDescriptionAllAsync() => await _context.DescriptionCourses.ToListAsync();

    public async Task<Entities.DescriptionCourse> GetDescriptionByIdAsync(Guid id) => await _context.DescriptionCourses.FirstOrDefaultAsync(i => i.Id == id);

    public async Task<Entities.DescriptionCourse> CreateDescription(DescriptionCourseDto descriptionCourseDto)
    {
        var descriptionCourse = descriptionCourseDto.Adapt<Entities.DescriptionCourse>();

        descriptionCourse.Id = new Guid();
        descriptionCourse.Title = descriptionCourseDto.Title;
        descriptionCourse.Review = descriptionCourseDto.Review;
        descriptionCourse.CourseId = descriptionCourseDto.CourseId;

        await _context.DescriptionCourses.AddAsync(descriptionCourse);
        await _context.SaveChangesAsync();
        return descriptionCourse;
    }

    public async Task<Entities.DescriptionCourse?> UpdateDescriptionAsync(Guid id, DescriptionCourseDto descriptionCourseDto)
    {
        var descriptionCourse = await _context.DescriptionCourses.FirstOrDefaultAsync(i => i.Id == id);
        if (descriptionCourse is null) return descriptionCourse;

        descriptionCourse.Review = descriptionCourseDto.Review;
        descriptionCourse.Title = descriptionCourseDto.Title;

        await _context.SaveChangesAsync();

        return descriptionCourse;

    }

    public async Task DeleteDescriptionAsync(Guid id)
    {
        var getDescriptionCourse = await _context.DescriptionCourses.FirstOrDefaultAsync(i => i.Id == id);
        if (getDescriptionCourse != null) _context.DescriptionCourses.Remove(getDescriptionCourse);
        await _context.SaveChangesAsync();
        
    }
}