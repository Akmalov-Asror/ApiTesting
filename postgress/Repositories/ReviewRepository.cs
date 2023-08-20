using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Services.Generics;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
public class ReviewRepository : GenericService<Review, AppDbContext.AppDbContext>
{
    public ReviewRepository(AppDbContext.AppDbContext context) : base(context)
    {

    }
}