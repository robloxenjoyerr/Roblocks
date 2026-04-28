using Microsoft.AspNetCore.Mvc;

namespace Roblocks.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController:ControllerBase
{
    
private static readonly string[] Games={
    "Adopt Me!",
    "Arsenal",
    "Bee Swarm Simulator",
    "Brookhaven RP",
    "Doors",
    "Dress to Impress",
    "Epic Minigames",
    "Flee the Facility",
    "Frontlines",
    "Grow a Garden",
    "Hide and Seek Extreme",
    "Jailbreak",
    "MeepCity",
    "The Mimic",
    "Murder Mystery 2",
    "Natural Disaster Survival",
    "Pet Simulator 99!",
    "Phantom Forces",
    "Piggy",
    "Rainbow Friends",
    "Royale High",
    "Scuba Diving at Quill Lake",
    "SharkBite",
    "Speed Run 4",
    "Theme Park Tycoon 2",
    "Tower of Hell",
    "Welcome to Bloxburg",
    "Work at a Pizza Place",
    "Blox Fruits",
    "BedWars",
    "World // Zero",
    "Tower Defense Simulator",
    "Blade Ball",
    "The Strongest Battlegrounds",
    "Evade",
    "PLS DONATE",
    "King Legacy",
    "Build A Boat For Treasure",
    "Anime Vanguards",
    "Sonic Speed Simulator"
};

    
    [HttpGet("{index}")]
    public IActionResult Get(int index)
    {
        const int RESPONSES_PER_PAGE = 20;
        var firstResponseValue=RESPONSES_PER_PAGE*index;
        var lastResponseValue = firstResponseValue + RESPONSES_PER_PAGE;
        
        if (lastResponseValue > Games.Length)
        {
            return NotFound("There are not enough games.");
        }
        return Ok(Games[firstResponseValue..lastResponseValue]);
    }
    
}