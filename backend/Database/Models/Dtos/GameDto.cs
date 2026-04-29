namespace Roblocks.Models.Dtos;

public class GameDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Tags { get; set; }
    public string[] Developers { get; set; }
    public int LivePlayers { get; set; }
}