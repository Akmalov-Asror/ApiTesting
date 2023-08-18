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
using postgress.ExtationFunction;
using postgress.Interfaces;
using BCryptNet = BCrypt.Net;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepository;
    public AuthController(IAuthRepository authRepository) => _authRepository = authRepository;

    [HttpGet, Authorize]
    public ActionResult<string> GetMyName() => Ok(CreateTokenInJwtAuthorizationFromUsers.GetMyId());

    [HttpGet("ListUsers"), Authorize]
    public async Task<IActionResult> GetAllUsers() => Ok(await _authRepository.GetAllUsers());

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UsersDto request) => Ok(await _authRepository.Register(request));

    [HttpPost("login")]
    public async Task<IActionResult> Login(UsersDto request) => Ok(await _authRepository.Login(request));

}
