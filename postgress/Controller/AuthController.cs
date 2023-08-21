using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.ExtationFunction;
using postgress.Interfaces;
using postgress.Validators;

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
