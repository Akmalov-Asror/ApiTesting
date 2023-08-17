using postgress.DTO_s;
using postgress.Entities;
using System.Security.Claims;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface IResultRepository
{
    Task<List<Result>> GetResultAllAsync();
    Task<Result> GetResultByIdAsync(Guid id);
    Task<Result> AddResultAsync(ClaimsPrincipal claims, Guid descriptionId, ResultDto resultDto);
    Task<Result> UpdateResultAsync(ClaimsPrincipal claims, Guid descriptionId, ResultDto resultDto);
    Task DeleteResultAsync(Guid id);

}