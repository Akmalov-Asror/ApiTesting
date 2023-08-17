using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace postgress.Controller;

[Route("api/[controller]")]
[ApiController]

public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateUser(UsersDto usersDto) => Ok(await _userRepository.CreateUserAsync(usersDto));  

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    public async Task<ActionResult> GetAllUsers() => Ok(await _userRepository.GetUserAllAsync() ?? new List<User?>());

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserAsync(Guid Id) => Ok(await _userRepository.GetUserAsync(Id));

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser(string email, UsersDto usersDto)
    {
        var users = await _userRepository.UpdateUserAsync(email, usersDto);
        if (users is null)
            return NotFound("This User is not Defined");
        return Ok(users);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _userRepository.DeleteUserAsync(id);
        return Ok("User is Deleted");
    }
}