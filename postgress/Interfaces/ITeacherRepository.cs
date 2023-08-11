using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface ITeacherRepository
{
    Task<List<Teacher?>> GetTeacherAllAsync();
    Task<Teacher> CreateTeacherAsync(TeacherDto teacherDto);
    Task<Teacher?> UpdateTeacherAsync(string fullName, TeacherDto teacherDto);
    Task DeleteTeacherAsync(Guid id);
}   