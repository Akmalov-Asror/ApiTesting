using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using postgress.DTO_s;
using postgress.Entities;
using postgress.Interfaces;

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
    public async Task<IActionResult> CreateUser(UsersDto usersDto)
    {
        var user = await _userRepository.CreateUserAsync(usersDto);
        return Ok(user);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
    public async Task<ActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetUserAllAsync();
        return Ok(users ?? new List<User?>());
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser(string email, UsersDto usersDto)
    {
        var users = await _userRepository.UpdateUserAsync(email, usersDto);
        if (users is null)
        {
            return NotFound("This User is Defined");
        }
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