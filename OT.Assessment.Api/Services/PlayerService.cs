using Microsoft.AspNetCore.Mvc;
using OT.Assessment.Database;
using OT.Assessment.Models;

namespace OT.Assessment.Services;
public class PlayerService
{
    private OTAssessmentContext _dbContext;
    private readonly ILogger<PlayerService> _logger;

    public PlayerService(OTAssessmentContext dbContext, ILogger<PlayerService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }


    public async Task<List<WagerDTO>> GetCasinoWagersAsync()
    {
        return [];
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
