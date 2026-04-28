using Microsoft.AspNetCore.Mvc;
using Roblocks.Models;
using Roblocks.Models.Dtos;

namespace Roblocks.Controllers;

[ApiController]
[Route("[controller]")]
public class Users:ControllerBase
{
    private readonly List<User> users = [];

    [HttpPost]
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
    public IActionResult GetFriends([FromRoute] string username)
    {
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            return NotFound("There is no user with the given username");
        }

        return Ok(user);
    }
}