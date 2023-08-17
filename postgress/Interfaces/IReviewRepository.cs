using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface IReviewRepository
{
    Task<Review?> GetAsync(Guid id);
    Task<List<Review>> GetAllAsync();
    Task<Review> CreateAsync(ReviewDto reviewDto);
    Task<Review> UpdateAsync(Guid id,ReviewDto reviewDto);
    Task DeleteAsync(Guid id);
}