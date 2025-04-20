using Microsoft.AspNetCore.Mvc;
using OT.Assessment.Database;

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


    public async Task<IActionResult> GetCasinoWagersAsync()
    {
        return;
    }

    public async Task<IActionResult> GetPlayerWagersByIdAsync(int playerId)
    {
        return;
    }
    public async Task<IActionResult> GetTopSpendersAsync(int count)
    {
        return;
    }
}
