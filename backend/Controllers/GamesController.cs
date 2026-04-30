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
    private readonly Mapper _mapper;

    public GamesController(GamesServices gamesService, Mapper mapper)
    {
        _mapper = mapper;
        _gamesService = gamesService;
    }

    public GameDto MapToDto(Games game)
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

    [HttpGet("insertDemoGames")]
    [ProducesResponseType<int>(StatusCodes.Status200OK)]
    [ProducesResponseType<int>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetInsertDemoGames()
    {
        Console.WriteLine("Inserting demo games now..");
        var success = await _gamesService.insertDemoGames();
        Console.WriteLine($"Inserted {success} demo games");
        return Ok(success);
    }
}