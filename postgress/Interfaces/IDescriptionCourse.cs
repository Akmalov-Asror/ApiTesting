using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface IDescriptionCourse
{
    Task<List<DescriptionCourse>> GetDescriptionAllAsync();
    Task<DescriptionCourse> GetDescriptionByIdAsync(Guid id);
    Task<DescriptionCourse> CreateDescription(DescriptionCourseDto descriptionCourseDto);
    Task<DescriptionCourse?> UpdateDescriptionAsync(Guid id,DescriptionCourseDto descriptionCourseDto);
    Task DeleteDescriptionAsync(Guid id);
}