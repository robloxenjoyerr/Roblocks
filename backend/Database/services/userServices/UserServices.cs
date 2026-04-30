using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roblocks.Models.Dtos;

namespace Roblocks.Database.services.userServices;

public class UserServices
{
    private readonly DataContext _context;

    public UserServices(DataContext context)
    {
        _context = context;
    }

    public async Task<UserDto> GetUserInfo(string username)
    {
        var userInfo = await _context.Users
            .Where(u => u.Username == username)
            .Select(u => new UserDto
            {
                Username =  u.Username,
                CurrentlyPlaying =  u.CurrentlyPlaying,
                GamesPlayed =  u.GamesPlayed,
                Hours = u.Hours,
                Favorites = u.Favorites,
                LastPlayed =  u.LastPlayed,
                avatarUrl =  u.avatarUrl,
            })
            .FirstOrDefaultAsync();
            
                
        return userInfo;
    }
}