using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Services;

public class CasinoWagersService
{
    private OTAssessmentContext _dbContext;
    private ILogger<CasinoWagersService> _logger;

    public CasinoWagersService(OTAssessmentContext dbContext, ILogger<CasinoWagersService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<bool> InsertCasinoWagersAsync(List<Wager> wagers)
    {
        try
        {
            await _dbContext.Wagers.AddRangeAsync(wagers);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException dbEx)
        {
            _logger.LogError(dbEx, "Database update failed while inserting casino wagers.");
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while inserting casino wagers.");
            return false;
        }
    }

}
