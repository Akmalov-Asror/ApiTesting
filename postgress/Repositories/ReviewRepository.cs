using JFA.DependencyInjection;
using Mapster;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;
[Scoped]
public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public ReviewRepository(AppDbContext.AppDbContext context) => _context = context;

    public async Task<Review?> GetAsync(Guid id)
    {
        return await _context.Reviews.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<Review>> GetAllAsync() => await _context.Reviews.ToListAsync();

    public async Task<Review> CreateAsync(ReviewDto reviewDto)
    {
        var review = reviewDto.Adapt<Review>();
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<Review> UpdateAsync(Guid id, ReviewDto reviewDto)
    {
        var findReview = await _context.Reviews.FirstOrDefaultAsync(u => u.Id == id);

        if (findReview == null) return findReview;

        findReview.Name = findReview.Name;
        findReview.Description = findReview.Description;
        findReview.DescriptionCourseId = findReview.DescriptionCourseId;

        await _context.SaveChangesAsync();

        return findReview;
    }

    public async Task DeleteAsync(Guid id)
    {
        var getReview = await _context.Reviews.FirstOrDefaultAsync(i => i.Id == id);
        _context.Reviews.Remove(getReview);
        await _context.SaveChangesAsync();
    }
}