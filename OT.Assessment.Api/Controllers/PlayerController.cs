using Mapster;
using Microsoft.AspNetCore.Mvc;
using OT.Assessment.Api.Models;
using OT.Assessment.Configuration;
using OT.Assessment.Services;
using System.Collections.Generic;
using System.Text.Json;

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
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> GetCasinoWagersAsync([FromBody] JsonElement wagerDTOs)
    {
        if (wagerDTOs.GetRawText() != string.Empty)
        {
            List<WagerDTO> wagerDTOsMapped = JsonSerializer.Deserialize<List<WagerDTO>>(wagerDTOs.GetRawText()) ?? [];

            if (wagerDTOsMapped.Any())
            {
                return Ok(await _playerService.ProcessCasinoWagersAsync(wagerDTOsMapped));
            }
        }

        return BadRequest();
    }

    [Route(PlayerControllerConfiguration.PlayerWagers)]
    [HttpGet]
    [ProducesResponseType(typeof(CasinoWagersDTO), 200)]
    public async Task<IActionResult> GetPlayerWagersByIdAsync(Guid playerId, int page, int pageSize)
    {
        return Ok(await _playerService.GetPlayerWagersByIdAsync(playerId, page, pageSize));
    }

    [Route(PlayerControllerConfiguration.TopSpenders)]
    [HttpGet]
    [ProducesResponseType(typeof(List<WagerDTO>), 200)]
    public async Task<IActionResult> GetTopSpendersAsync(int counter)
    {
        return Ok(await _playerService.GetTopSpendersAsync(counter));
    }
};
