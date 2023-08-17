using postgress.DTO_s;
using postgress.Entities;
using System.Security.Claims;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface IHomeworkRepository
{
    Task<List<Homework?>> GetHomeworkAllAsync();
    Task<Homework> CreateHomeworkAsync(ClaimsPrincipal claims, Guid taskId,HomeworkDto homeworkDto);
    Task<Homework?> UpdateHomeworkAsync(string name, Guid taskId ,HomeworkDto homeworkDto);
    Task DeleteHomeworkAsync(Guid id);
}