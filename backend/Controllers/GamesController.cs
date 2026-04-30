using System.Runtime.InteropServices.JavaScript;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roblocks.Database.Models;
using Roblocks.Models.Dtos;
using Roblocks.Database.services;
using Roblocks.Database.services.gamesServices;
using Roblocks.Models;

namespace Roblocks.Controllers;

[Route("api/v1/[controller]")]
public class GamesController: ControllerBase
{
    private readonly GamesServices _gamesService;
    private readonly IMapper _mapper;

    public GamesController(GamesServices gamesService, IMapper mapper)
    {
        _mapper = mapper;
        _gamesService = gamesService;
    }

    [NonAction]
    public GameDto MapToDto(Game game)
    {
        return _mapper.Map<GameDto>(game);
    }

    [HttpGet("{index}")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGames(int index = 0, int maxGamesPerIndex = 20, string filterByTag = "", string filterByDeveloper = "", string filterByPlayers = "")
    {
        var games = await _gamesService.GetGamesFromDb();

        
        return Ok(games);
    }

    [HttpGet("GamePage/{gameName}")]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGamePageInfo(string gameName)
    {
        var gamePageInfos = await _gamesService.GetGamePageInfos(gameName);

       if (gamePageInfos != null)
       {
        return Ok(gamePageInfos);
       } 
       return NotFound($"Game {gameName} not found");
    }
    
    [HttpPost("insertDemoGames")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType<int>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInsertDemoGames()
    {
        try
        {
         await _gamesService.InsertDemoGames();
         return Ok();

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}