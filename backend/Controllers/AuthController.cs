using Microsoft.AspNetCore.Mvc;
using Roblocks.Database.services.gamesServices;
using Roblocks.Models;
using Roblocks.Models.Dtos;
using AutoMapper;
using Roblocks.Database.services.userServices;
using Microsoft.AspNetCore.RateLimiting;
using JWT;
using Microsoft.AspNetCore.Authorization;

namespace Roblocks.Controllers;

public class AuthController : ControllerBase
{
    private readonly GamesServices _gamesService;
    private readonly UserServices _userServices;
    private readonly IMapper _mapper;
    public AuthController(UserServices userServices, GamesServices gamesService, IMapper mapper)
    {
        _mapper = mapper;
        _userServices = userServices;
        _gamesService = gamesService;
    }
    // Register new User => no OAuth yet
    [EnableRateLimiting("strict")] // oder fixwed fpr 10x pro min
    [Authorize]
    [HttpPost("register")]
    [ProducesResponseType<User>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUserDto([FromBody] CreateUserDto user)
    {
        var alreadyExists = await _userServices.GetUserInfo(user.Username, user.Email);
        Console.WriteLine("Already user in DB? :  " + alreadyExists ?? "NO");
        
        if(alreadyExists != null) return BadRequest("Username already exists");
        var createdUser = await _userServices.CreateUser(user.Username, user.Email ,user.Password);
        
        return Ok(createdUser);
    }
}