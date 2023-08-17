using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Interfaces;
using Task = postgress.Entities.Task;

namespace postgress.Repositories;
[Scoped]
public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public TaskRepository(AppDbContext.AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Task?>> GetTaskAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Task?> GetTaskByIdAsync(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Task> CreateTaskAsync(TaskDto taskDto)
    {
        var task = taskDto.Adapt<Task>();
        
        task.Name = taskDto.Name;
        task.Desc = taskDto.Desc;
        task.Date = taskDto.Date;
        task.Status = taskDto.Status;
        task.LessonId = taskDto.LessonId;
        taskDto.CommentId = taskDto.CommentId;

         await _context.Tasks.AddAsync(task);
         await _context.SaveChangesAsync();

         return task;
    }

    public async Task<Task?> UpdateTaskAsync(string name, TaskDto taskDto)
    {
        var taskUpdate = await _context.Tasks.FirstOrDefaultAsync(n => n.Name == name);
        if (taskUpdate == null) return taskUpdate;

        taskUpdate.Name = taskDto.Name;
        taskUpdate.Desc = taskDto.Desc;
        taskUpdate.Date = taskDto.Date;
        taskUpdate.Status = taskDto.Status;
        taskUpdate.LessonId = taskDto.LessonId;
        taskUpdate.CommentId = taskDto.CommentId;

        await _context.SaveChangesAsync();

        return taskUpdate;
    }

    public async System.Threading.Tasks.Task DeleteTaskAsync(Guid id)
    {
        var deleteTask = await _context.Tasks.FindAsync(id);
        if (deleteTask != null) _context.Tasks.Remove(deleteTask);
        await _context.SaveChangesAsync();
    }
}