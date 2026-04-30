using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roblocks.Models.Dtos;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Roblocks.Models;

namespace Roblocks.Database.services.userServices;

public class UserServices
{
    private readonly DataContext _context;
    
    public UserServices(DataContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> GetUserInfo(string username, string? email = null)
    {
        var userInfo = await _context.Users
            .Where(u => u.Username == username || (email != null && u.Email == email))
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
        Console.WriteLine("User exists?: ", userInfo);
        return userInfo;
    }

    public async Task<UserDto> CreateUser(string username, string email, string password)
    {
        string hashedPw = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            Email = email,
            HashedPassword = hashedPw,
        };

        _context.Add(user);
        await _context.SaveChangesAsync();

        
        return new UserDto
        {
            Username = user.Username,
            avatarUrl = user.avatarUrl,
            CurrentlyPlaying = user.CurrentlyPlaying,
            GamesPlayed = user.GamesPlayed,
            LastPlayed = user.LastPlayed,
            Hours = user.Hours,
            Favorites = user.Favorites,
        };
    }
}