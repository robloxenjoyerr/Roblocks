namespace Roblocks.Models;

public class User
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid Id { get; set; }
    public User[] Friends { get; set; }
}