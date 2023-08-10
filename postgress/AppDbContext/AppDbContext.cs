using Microsoft.EntityFrameworkCore;
using postgress.Entities;
using Task = postgress.Entities.Task;

namespace postgress.AppDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
    public DbSet<User?> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<DescriptionCourse> DescriptionCourses { get; set; }
    public DbSet<Homework> Homework { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Test> Tests { get; set; }



}