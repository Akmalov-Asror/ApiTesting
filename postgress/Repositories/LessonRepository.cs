using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Services.Generics;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
public class LessonRepository : GenericService<Lesson, AppDbContext.AppDbContext>
{
    public LessonRepository(AppDbContext.AppDbContext context) : base(context) { }
}