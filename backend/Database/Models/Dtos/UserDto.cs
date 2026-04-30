namespace Roblocks.Models.Dtos;

public class UserDto
{
    public string Username { get; set; }
    public string CurrentlyPlaying { get; set; } = "Not playing";
    public string GamesPlayed { get; set; } = "None played";
    public string LastPlayed { get; set; } = "Nothing played";
    public float Hours { get; set; } = 0;
    public string Favorites { get; set; } = "No favorites";
    public string avatarUrl { get; set; } = "";
}