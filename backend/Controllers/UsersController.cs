using Microsoft.AspNetCore.Mvc;
using Roblocks.Database.services.gamesServices;
using Roblocks.Models;
using Roblocks.Models.Dtos;
using AutoMapper;
using Roblocks.Database.services.userServices;

namespace Roblocks.Controllers;

[Route("api/v1/[controller]")]
public class UsersController: ControllerBase
{
    private readonly GamesServices _gamesService;
    private readonly UserServices _userServices;
    private readonly IMapper _mapper;
    public UsersController(UserServices userServices, GamesServices gamesService, IMapper mapper)
    {
        _mapper = mapper;
        _userServices = userServices;
        _gamesService = gamesService;
    }

    [NonAction]
    private UserDto MapToDto(User user)
    {
        return _mapper.Map<UserDto>(user);
    }
    
    [HttpPost]
    [ProducesResponseType<User>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
    public  IActionResult CreateUserDto(CreateUserDto user)
    {
       return Ok("");
    }

    // Get single user info
    [HttpGet("{username}")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFriendInfo([FromRoute] string username){
        try
        {
            var userInfo = await _userServices.GetUserInfo(username);
            Console.WriteLine("USER INFO --------------------");
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userInfo));
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    // Get multiple users info  
    [HttpGet("{username}/friends")]
    [ProducesResponseType<string[]>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
    public IActionResult GetFriends([FromRoute] string username)
    {
        return Ok("");
    }
}