using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface ICourseRepository
{
    Task<List<Course?>> GetCourseAllAsync();
    Task<Course?> GetCourseByIdAsync(Guid id);
    Task<Course> CreateCourseAsync(CourseDto courseDto);
    Task<Course?> UpdateCourseAsync(CourseDto courseDto);
    Task DeleteCourseAsync(Guid id);
}