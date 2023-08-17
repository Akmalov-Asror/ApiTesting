using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;

public class ResultRepository : IResultRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public ResultRepository(AppDbContext.AppDbContext context) => _context = context;

    public async Task<List<Result>> GetResultAllAsync()
    {
        return await _context.Results.ToListAsync();
    }

    public async Task<Result> GetResultByIdAsync(Guid id) => await _context.Results.FirstOrDefaultAsync(i => i.Id == id);

    public async Task<Result> AddResultAsync(ClaimsPrincipal claims, Guid descriptionId,ResultDto resultDto)
    {
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _context.Results.FindAsync(userId);
        if (result == null)
        {
            result = new Result()
            {
                Id = new Guid(),
                UserId = userId,
                ImgPath = resultDto.ImgPath,
                DescriptionCourseId = descriptionId
            };
            await _context.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        await _context.AddAsync(result);
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<Result> UpdateResultAsync(ClaimsPrincipal claims, Guid descriptionId, ResultDto resultDto)
    {
        var userId = Guid.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var result = await _context.Results.FindAsync(userId);

        if (result == null)
        {
            return result;
        }

        result.ImgPath = resultDto.ImgPath;
        result.DescriptionCourseId = descriptionId;

        await _context.AddAsync(result);
        await _context.SaveChangesAsync();
        return result;
    }

    public Task DeleteResultAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}