using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IDataAccess _dataAccess;

    public PlayerController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    [HttpPost]
    public async Task<ActionResult<Player>> CreatePlayerAsync(Player player)
    {
        try
        {

            Player p = await _dataAccess.CreatePlayerAsync(player);
            
            Console.WriteLine("controller");

            return Created($"/Player/{p.PlayerId}", p);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet]
    public async Task<ActionResult<ICollection<Player>>> GetAllAsync()
    {
        try
        {

            ICollection<Player> players = await _dataAccess.GetAllPlayersAsync();
            return Ok(players);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("{playerId:int}")]
    public async Task<ActionResult> AddScoreToPlayerAsync([FromBody]HoleScore holeScore, [FromRoute]int playerId)
    {
        try
        {

            await _dataAccess.AddScoreToPlayerAsync(holeScore, playerId);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}