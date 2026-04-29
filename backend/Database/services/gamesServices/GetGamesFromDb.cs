using Microsoft.EntityFrameworkCore;
using Roblocks.Models.Dtos;

namespace Roblocks.Database.services.gamesServices;

public class GetGamesFromDb
{
    private readonly DataContext _context;
    public async Task<List<GameDto>> GetGames(int index = 0, int maxGamesPerIndex = 20)
    {
        // _context.games
        await Task.Delay(100); // simuliert DB

        var games = await _context.Games.ToListAsync();

        return new List<GameDto>
        {
            new GameDto { Name = "Game1", LivePlayers = 100 },
            new GameDto { Name = "Game2", LivePlayers = 200 }
        };
    }
}