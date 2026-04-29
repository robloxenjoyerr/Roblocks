namespace Roblocks.Database.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Games
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Publisher { get; set; }
    public string ImageUrl { get; set; }
    public int LivePlayers { get; set; }
}