using System.ComponentModel.DataAnnotations;

namespace Roblocks.Database.Models;

public class Users
{
    [Key] public Guid Id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    
    public string avatarUrl  { get; set; }
}