namespace Roblocks.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key] public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string avatarUrl { get; set; } = "";
    public User[] Friends { get; set; }
    
    public string CurrentlyPlaying { get; set; } = "Not playing";
    public string GamesPlayed { get; set; } = "None played";
    public string LastPlayed { get; set; } = "None played";
    public float Hours { get; set; } = 0;
    public string Favorites { get; set; } = "No favorites";
}