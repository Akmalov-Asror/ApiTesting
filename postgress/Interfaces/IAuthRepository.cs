using postgress.DTO_s;
using postgress.Entities;

namespace postgress.Interfaces;

public interface IAuthRepository
{
    Task<User> Register(UsersDto userDto);
    Task<string> Login(UsersDto userDto);
    Task<List<User>> GetAllUsers();
}