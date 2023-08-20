using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Services.Generics;
using Task = postgress.Entities.Task;

namespace postgress.Repositories;
public class TaskRepository : GenericService<Task, AppDbContext.AppDbContext>
{
    public TaskRepository(AppDbContext.AppDbContext context) : base(context)
    {

    }
}