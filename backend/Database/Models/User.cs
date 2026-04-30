namespace Roblocks.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key] public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public string avatarUrl { get; set; } = "";
    
    public ICollection<Friendship> FriendshipsInitiated { get; set; } = new List<Friendship>();
    public ICollection<Friendship> FriendshipsReceived { get; set; } = new List<Friendship>();
    
    public string CurrentlyPlaying { get; set; } = "Not playing";
    public string GamesPlayed { get; set; } = "None played";
    public string LastPlayed { get; set; } = "None played";
    public float Hours { get; set; } = 0;
    public string Favorites { get; set; } = "No favorites";
}

public class Friendship
{
    [Key] public Guid Id { get; set; }
    
    public Guid RequesterId { get; set; }
    public User Requester { get; set; }
    
    public Guid ReceiverId { get; set; }
    public User Receiver { get; set; }
    
    public FriendshipStatus Status { get; set; } = FriendshipStatus.Pending;
}

public enum FriendshipStatus
{
    Pending,  
    Accepted, 
    Declined  
}