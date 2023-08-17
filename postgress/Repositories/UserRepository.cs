using System.IdentityModel.Tokens.Jwt;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Task = System.Threading.Tasks.Task;
using JFA.DependencyInjection;

namespace postgress.Repositories;
[Scoped]
public class UserRepository : IUserRepository
{
    private readonly AppDbContext.AppDbContext _context;
    private readonly IConfiguration _configuration;
    public UserRepository(AppDbContext.AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<User?> GetUserAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<List<User?>> GetUserAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<string> CreateUserAsync(UsersDto usersDto)
    {  
        var user =  usersDto.Adapt<User>();
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();

        var io = user.Id.ToString();
        var token = GenerateJwtToken(io);

        return token;
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

    private string GenerateJwtToken(string userId)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId)
        };

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}