using Microsoft.AspNetCore.Mvc;
using OT.Assessment.Configuration;

namespace OT.Assessment.Controllers;

[ApiController]
[Route(PlayerControllerConfiguration.PlayerController)]
public class PlayerController : Controller
{
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(ILogger<PlayerController> logger)
    {
        _logger = logger;
    }

    [Route(PlayerControllerConfiguration.CasinoWager)]
    [HttpPost]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> GetCasinoWagersAsync()
    {
        return;
    }

    [Route(PlayerControllerConfiguration.PlayerWagers)]
    [HttpGet]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> GetPlayerWagersByIdAsync(int playerId)
    {
        return;
    }

    [Route(PlayerControllerConfiguration.TopSpenders)]
    [HttpGet]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> GetTopSpendersAsync(int count)
    {
        return;
    }
};
