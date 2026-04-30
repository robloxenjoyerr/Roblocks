using Microsoft.EntityFrameworkCore;
using Roblocks.Models.Dtos;

using System.Text.Json;
using Roblocks.Database.Models;

namespace Roblocks.Database.services.gamesServices;

public class GamesServices
{
    private readonly DataContext _context;

    public GamesServices(DataContext context)
    {
        _context = context;
    }

    public async Task<List<GameDto>> GetGamesFromDb(int index = 0, int maxGamesPerIndex = 20, string filterByTag = "", string filterByDeveloper = "", string filterByPlayers = "")
    {
        var games = await _context.Games
            .AsQueryable()
            .Skip(index * maxGamesPerIndex)
            .Take(maxGamesPerIndex)
            .Select(g => new GameDto
            {
                Id = g.Id,
                Name = g.Name,
                LivePlayers = g.LivePlayers,
                Description = g.Description,
                ImageUrl = g.ImageUrl,
            })
            .ToListAsync();
        Console.WriteLine(games);
        return games;
    }
    
    public async Task<List<GameDto>> insertDemoGames()
    {
        var json = await File.ReadAllTextAsync(Path.GetFullPath("./tempGamesJson/games.json"));
        Console.WriteLine($"JSON: {json}");
        var demoGames = JsonSerializer.Deserialize<List<GameDto>>(json);
        Console.WriteLine($"DEMOGAMES:");
        foreach (var g in demoGames)
        {
            Console.WriteLine($"{g.Name} - {g.Description} - {g.Id} - {g.LivePlayers}");
        }
        var entities = demoGames.Select(g => new Games
        {
            
            Name = g.Name,
            LivePlayers = g.LivePlayers,
            Description = g.Description,
            ImageUrl = g.ImageUrl,
            
    
        }).ToList();
        
        _context.Games.AddRange(entities);
        await _context.SaveChangesAsync();

        return demoGames;
    }
}