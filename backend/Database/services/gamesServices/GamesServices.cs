using Microsoft.EntityFrameworkCore;
using Roblocks.Models.Dtos;

using System.Text.Json;
using AutoMapper;
using Roblocks.Database.Models;

namespace Roblocks.Database.services.gamesServices;

public class GamesServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GamesServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    public async Task<GamePageDto?> GetGamePageInfos(string gameName)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(g => g.Name == gameName);
        return _mapper.Map<GamePageDto>(game);
    }
    
    public async Task InsertDemoGames()
    {
        var json = await File.ReadAllTextAsync(Path.GetFullPath("./tempGamesJson/games.json"));
        Console.WriteLine($"JSON: {json}");
        var demoGames = JsonSerializer.Deserialize<List<GameDto>>(json);
        if (demoGames is null)
        {
            throw new Exception("No Games Found in games.json");
        }
        var entities = demoGames.Select(g => new Game
            {
                Name = g.Name,
                Description = g.Description,
                Publisher = "Demo Publisher",
                ImageUrl = g.ImageUrl,
                LivePlayers = g.LivePlayers,
                Likes = 1234,
                Dislikes = 0,
                LeaderBoard = "No Leaderboard",
                ReleaseDate = DateTime.Now,
            }).ToList();
        
        await _context.Games.AddRangeAsync(entities);
        await _context.SaveChangesAsync();

    }
}