using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public TeacherRepository(AppDbContext.AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher?>> GetTeacherAllAsync()
    {
        return await _context.Teachers.ToListAsync();
    }

    public async Task<Teacher> CreateTeacherAsync(TeacherDto teacherDto)
    {
        var teacher = teacherDto.Adapt<Teacher>();

        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();

        return teacher;
    }

    public async Task<Teacher?> UpdateTeacherAsync(string fullName, TeacherDto teacherDto)
    {
        var findTeacher = await _context.Teachers.FirstOrDefaultAsync(u => u.FullName == fullName);

        if (findTeacher == null) return findTeacher;

        findTeacher.FullName = teacherDto.FullName;
        findTeacher.Img = teacherDto.Img;
        findTeacher.Desc = teacherDto.Desc;

        await _context.SaveChangesAsync();

        return findTeacher;

    }

    public async Task DeleteTeacherAsync(Guid id)
    {
        var deleteTeacher = await _context.Teachers.FindAsync(id);
        if (deleteTeacher != null) _context.Teachers.Remove(deleteTeacher);
        await _context.SaveChangesAsync();
    }
}