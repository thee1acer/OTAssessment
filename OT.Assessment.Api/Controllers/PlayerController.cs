using Microsoft.AspNetCore.Mvc;
using OT.Assessment.Configuration;
using OT.Assessment.Models;
using OT.Assessment.Services;

namespace OT.Assessment.Controllers;

[ApiController]
[Route(PlayerControllerConfiguration.PlayerController)]
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
    [ProducesResponseType(typeof(List<WagerDTO>), 200)]
    public async Task<IActionResult> GetCasinoWagersAsync()
    {
        return Ok(await _playerService.GetCasinoWagersAsync());
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
    public async Task<IActionResult> GetTopSpendersAsync(int count)
    {
        return Ok(await _playerService.GetTopSpendersAsync(count));
    }
};
