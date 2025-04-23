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
            _logger.LogDebug("[#] Inserting into DB [#] ");

            await _dbContext.Wagers.AddRangeAsync(wagers);
            await _dbContext.SaveChangesAsync();
            
            _logger.LogDebug("[#] Inserting into DB done![#] ");
            return true;
        }
        catch (DbUpdateException dbEx)
        {
            _logger.LogError($"Database update failed while inserting casino wagers. {dbEx}");
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An unexpected error occurred while inserting casino wagers: {ex}");
            return false;
        }
    }

}
