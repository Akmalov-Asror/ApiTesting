using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface ILessonRepository
{
    Task<Lesson> GetLessonAsync(Guid id);
    Task<List<Lesson>> GetLessonAllAsync();
    Task<Lesson> AddLessonAsync(LessonDto lessonDto);
    Task<Lesson> UpdateLessonAsync(Guid id, LessonDto lessonDto);
    Task DeleteLessonAsync(Guid id);
}