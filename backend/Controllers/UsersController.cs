using Microsoft.AspNetCore.Mvc;
using Roblocks.Models;
using Roblocks.Models.Dtos;

namespace Roblocks.Controllers;

[Route("api/v1/[controller]")]
public class UsersController: ControllerBase
{
    private readonly List<User> users = [];

    [HttpPost]
    [ProducesResponseType<User>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
    public  IActionResult CreateUserDto(CreateUserDto user)
    {
        if (users.Any(u => u.Email == user.Email))
        {
            return BadRequest("User with the same email already exists");
        }

        if (user.Username == "")
        {
           return BadRequest("Username cannot be empty"); 
        }

        if (user.Password == "")
        {
            return BadRequest("Password cannot be empty");
        }
        return Ok(user);
    }

    [HttpGet("{username}/friends")]
    [ProducesResponseType<string[]>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
    public IActionResult GetFriends([FromRoute] string username)
    {
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            return NotFound("There is no user with the given username");
        }

        return Ok(user.Friends.Select(userDto => userDto.Username));
    }
}