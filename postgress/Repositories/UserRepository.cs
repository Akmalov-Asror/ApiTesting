using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace postgress.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public UserRepository(AppDbContext.AppDbContext context)
    {
        _context = context;
    }


    public async Task<User?> GetUserAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<List<User?>> GetUserAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> CreateUserAsync(UsersDto usersDto)
    {
        var user =  usersDto.Adapt<User>();
         
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> UpdateUserAsync(string email, UsersDto usersDto)
    {
        var findUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        findUser.Name = usersDto.Name;
        findUser.Email = email;
        findUser.Password = usersDto.Password;

        await _context.SaveChangesAsync();

        return findUser;

    }

    public async Task DeleteUserAsync(Guid id)
    {
        var deleteUser = await _context.Users.FindAsync(id);
        _context.Users.Remove(deleteUser);
        await _context.SaveChangesAsync();

    }
}