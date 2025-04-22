using Microsoft.AspNetCore.Mvc;
using OT.Assessment.Database;
using OT.Assessment.Api.Models;
using OT.Assessment.ProduceCasinoWager.Worker.Services;
using System.Text.Json;

namespace OT.Assessment.Services;
public class PlayerService
{
    private OTAssessmentContext _dbContext;
    private CasinoWagerProducer _casinoWagerProducer;
    private readonly ILogger<PlayerService> _logger;

    public PlayerService(CasinoWagerProducer casinoWagerProducer, OTAssessmentContext dbContext, ILogger<PlayerService> logger)
    {
        _casinoWagerProducer = casinoWagerProducer;
        _dbContext = dbContext;
        _logger = logger;
    }


    public async Task<bool> ProcessCasinoWagersAsync(List<WagerDTO> wagerDTOs)
    {
        await _casinoWagerProducer.SendMessageAsync(JsonSerializer.Serialize(wagerDTOs));

        return true;
    }

    public async Task<List<WagerDTO>> GetPlayerWagersByIdAsync(int playerId)
    {
        return [];
    }
    public async Task<List<WagerDTO>> GetTopSpendersAsync(int count)
    {
        return [];
    }
}
