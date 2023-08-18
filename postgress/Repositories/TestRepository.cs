using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
[Scoped]
public class TestRepository : ITestRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public TestRepository(AppDbContext.AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Test>> GetTestCollections()
    {
        return await _context.Tests.Include(x => x.Choices).ToListAsync();
    }
     
    public async Task<Test> AddTest(TestDto testDto)
    {
        var test = testDto.Adapt<Test>();
        _context.Tests.Add(test);
        await _context.SaveChangesAsync();
        return test;
    }

    public async Task<Test?> UpdateTest(Guid id, TestDto testDto)
    {
        var updatedTest = await _context.Tests.Include(x => x.Choices).FirstOrDefaultAsync(x => x.Id == id);

        if (updatedTest is null) return updatedTest;

        updatedTest.QuestionText = testDto.QuestionText;
        updatedTest.CorrectAnswerQuestion = testDto.CorrectAnswerQuestion;
        updatedTest.Choices = testDto.Choices;

        await _context.SaveChangesAsync();

        return updatedTest;
    }

    public async Task DeleteTest(Guid id)
    {
        var deleteTest = await _context.Tests.Include(x => x.Choices).FirstOrDefaultAsync(i => i.Id == id);
        if (deleteTest != null) _context.Tests.Remove(deleteTest);
        await _context.SaveChangesAsync();
    }
}