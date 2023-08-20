using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using postgress.Services.Generics;

namespace postgress.Repositories;

public class DescriptionCourseRepository : GenericService<DescriptionCourse, AppDbContext.AppDbContext>
{
    public DescriptionCourseRepository(AppDbContext.AppDbContext context) : base(context) { }
}