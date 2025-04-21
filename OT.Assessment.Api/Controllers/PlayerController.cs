using Microsoft.AspNetCore.Mvc;
using OT.Assessment.Configuration;
using OT.Assessment.Api.Models;
using OT.Assessment.Services;

namespace OT.Assessment.Controllers;

[ApiController]
[Route("api/player")]
public class PlayerController : Controller
{
    private readonly ILogger<PlayerController> _logger;
    private PlayerService _playerService;

    public PlayerController(PlayerService playerService, ILogger<PlayerController> logger)
    {
        _playerService = playerService;
        _logger = logger;
    }

    [Route(PlayerControllerConfiguration.CasinoWager)]
    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> GetCasinoWagersAsync([FromBody] string listOfWagersJson)
    {
        return Ok(await _playerService.ProcessCasinoWagersAsync(listOfWagersJson));
    }

    [Route(PlayerControllerConfiguration.PlayerWagers)]
    [HttpGet]
    [ProducesResponseType(typeof(List<WagerDTO>), 200)]
    public async Task<IActionResult> GetPlayerWagersByIdAsync(int playerId)
    {
        return Ok(await _playerService.GetPlayerWagersByIdAsync(playerId));
    }

    [Route(PlayerControllerConfiguration.TopSpenders)]
    [HttpGet]
    [ProducesResponseType(typeof(List<WagerDTO>), 200)]
    public async Task<IActionResult> GetTopSpendersAsync(int counter)
    {
        return Ok(await _playerService.GetTopSpendersAsync(counter));
    }
};
