namespace Roblocks.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string avatarUrl { get; set; }
    public Guid Id { get; set; }
    public User[] Friends { get; set; }
}