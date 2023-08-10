using postgress.DTO_s;
using postgress.Entities;
using Task = System.Threading.Tasks.Task;

namespace postgress.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserAsync(Guid id);
    Task<List<User?>> GetUserAllAsync();
    Task<User> CreateUserAsync(UsersDto usersDto);
    Task<User> UpdateUserAsync(string email, UsersDto usersDto);
    Task DeleteUserAsync(Guid id);
}