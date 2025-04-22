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
        await _casinoWagerProducer.SendMessageAsync(JsonSerializer.Serialize(wagerDTOs));

        return true;
    }

    public async Task<CasinoWagersDTO?> GetPlayerWagersByIdAsync(Guid playerId, int page, int pageSize)
    {
        if (page == 0) return default;

        var transactions = await _dbContext.Transactions
            .Where(v => v.UserId == playerId)
                .ToListAsync();

        if (!transactions.Any()) return default;

        var transactionIds = transactions.Select(v => v.Id).ToList();

        var wagers = await _dbContext.Wagers
            .Include(v => v.Transaction)
            .Include(v => v.Game)
            .Where(v => transactionIds.Contains(v.TransactionId))
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
                    Amount = v.Transaction.Amount,
                    CreatedDate = v.Transaction.CreatedDateTime,
                    Game = v.Game.Name,
                    Provider = v.Provider.Name,
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

        var transactions = await _dbContext.Transactions
            .Include(v => v.User)
            .OrderByDescending(v => v.Amount)
                .Take(count)
            .ToListAsync();

        if (!transactions.Any()) return [];

        var result = transactions.Select
            (
                v =>
                    new SpenderDTO
                    {
                        AccountId = v.User.AccountId,
                        UserName = v.User.UserName,
                        TotalAmountSpend = v.Amount
                    }
            ).ToList();

        return result;
    }
}
