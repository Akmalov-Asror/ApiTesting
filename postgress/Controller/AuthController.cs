using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using postgress.DTO_s;
using postgress.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext.AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthController(IConfiguration configuration, AppDbContext.AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet, Authorize]
    public ActionResult<string> GetMyName() => Ok(GetMyId());

    [HttpPost("register")]
    public ActionResult<User> Register(UsersDto request)
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

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UsersDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == request.Email);

        if (user == null)
        {
            return BadRequest("User not found.");
        }

        var verify = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        if (verify)
        {
            string token = CreateToken(user);
            return Ok(token);
        }
        else
        {
            return BadRequest("Wrong password");
        }
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asfsafsasafjsafjksafksafsafsafsafasfasfafasfsafasfsafsafassaf"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(7),
            signingCredentials: creds,
            issuer: "http://localhost:5069/"
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
    private string GetMyId()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext is not null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        return result;
    }
}
