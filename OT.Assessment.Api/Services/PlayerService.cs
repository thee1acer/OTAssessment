using Microsoft.AspNetCore.Mvc;
using OT.Assessment.Database;
using OT.Assessment.Api.Models;
using OT.Assessment.ProduceCasinoWager.Worker.Services;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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
        try
        {
            var message = JsonSerializer.Serialize(wagerDTOs);
            await _casinoWagerProducer.SendMessageAsync(message);

            _logger.LogDebug("[#] Successfully serialized and published message [#]");
            return true;
        }
        catch(Exception ex)
        {
            _logger.LogError("[#] Failed to serialize dtos[#]");
            return false;
        }        
    }

    public async Task<CasinoWagersDTO?> GetPlayerWagersByIdAsync(string userName, int page, int pageSize)
    {
        if (page == 0) return default;

        var wagers = await _dbContext.Wagers
            .Where(v => v.UserName == userName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
            .ToListAsync();

        if (!wagers.Any()) return default;

        var casinoWagersMapped = 
            wagers.Select
            (
                v =>
                new CasinoWagerDTO
                {
                    Amount = v.Amount,
                    CreatedDate = v.CreatedDateTime,
                    Game = v.GameName,
                    Provider = v.Provider,
                    WagerId = v.Id,
                }
            ).ToList();

        var result =
            new CasinoWagersDTO
            {
                Page = page,
                PageSize = pageSize,
                Total = wagers.Count,
                TotalPages = wagers.Count % pageSize,
                Wagers = casinoWagersMapped
            };

        return result;
    }
    public async Task<List<SpenderDTO>> GetTopSpendersAsync(int count)
    {
        if (count == 0) return [];

        var wagers = await _dbContext.Wagers
            .OrderByDescending(v => v.Amount)
                .Take(count)
            .ToListAsync();

        var result = wagers.Select
            (
                v =>
                    new SpenderDTO
                    {
                        AccountId = v.AccountId,
                        UserName = v.UserName,
                        TotalAmountSpend = v.Amount
                    }
            ).ToList();

        return result;
    }
}
