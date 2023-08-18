using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Services.ExistEntity;
using postgress.Services.Generics;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
public class CourseRepository : GenericService<Course, AppDbContext.AppDbContext>
{
    public CourseRepository(AppDbContext.AppDbContext _context) : base(_context)
    {

    }
}