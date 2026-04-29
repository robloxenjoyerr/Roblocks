using Microsoft.EntityFrameworkCore;
using Roblocks.Models.Dtos;

using System.Text.Json;
using Roblocks.Database.Models;

namespace Roblocks.Database.services.gamesServices;

public class GamesService
{
    private readonly DataContext _context;

    public GamesService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GameDto>> GetGames(int index = 0, int maxGamesPerIndex = 20)
    {
        var games = await _context.Games
            .AsQueryable()
            .Skip(index * maxGamesPerIndex)
            .Take(maxGamesPerIndex)
            .Select(g => new GameDto
            {
                Name = g.Name,
                LivePlayers = g.LivePlayers
            })
            .ToListAsync();

        return games;
    }
    
    public async Task<List<GameDto>> insertDemoGames()
    {
        var json = await File.ReadAllTextAsync("../../tempGamesJson/games.json");

        var demoGames = JsonSerializer.Deserialize<List<GameDto>>(json);

        var entities = demoGames.Select(g => new Games
        {
            Name = g.Name,
    
        }).ToList();
        
        _context.Games.AddRange(entities);
        await _context.SaveChangesAsync();

        return demoGames;
    }
}