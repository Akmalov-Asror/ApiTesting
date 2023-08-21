using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Encryptors;
using postgress.Entities;
using postgress.ExtationFunction;
using postgress.Interfaces;
using BCryptNet = BCrypt.Net;

namespace postgress.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext.AppDbContext _context;

    public AuthRepository(AppDbContext.AppDbContext context) => _context = context;

    public async Task<User> Register(UsersDto request)
    {
        var salt = BCryptNet.BCrypt.GenerateSalt();
        var passwordHash
            = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);

        var user = new User
        {
            Id = new Guid(),
            Name = request.Name,
            Email = request.Email,
            Password = passwordHash
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<string> Login(UsersDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == request.Email);

        if (user != null)
        {
            var verify = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (verify)
            {
                var token = CreateTokenInJwtAuthorizationFromUsers.CreateToken(user);
                return token;
            }
            else throw new BadHttpRequestException("Wrong password");
        }

        throw new BadHttpRequestException("User not found.");
    }

    public async Task<List<User>> GetAllUsers() => await _context.Users.ToListAsync();
}