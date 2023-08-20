using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Services.Generics;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
public class TeacherRepository : GenericService<Teacher, AppDbContext.AppDbContext>
{
    public TeacherRepository(AppDbContext.AppDbContext context) : base(context)
    {

    }
}