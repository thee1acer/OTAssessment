using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Services;

public class CasinoWagersService
{
    private IServiceProvider _serviceProvider;
    private ILogger<CasinoWagersService> _logger;

    public CasinoWagersService(IServiceProvider serviceProvider, ILogger<CasinoWagersService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    public async Task<bool> InsertCasinoWagersAsync(List<Wager> wagers)
    {
        try
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<OTAssessmentContext>();
                
                _logger.LogDebug("[#] Inserting into DB [#] ");

                var bomberIds = wagers.Select(w => w.Id).ToList();

                var existingIds = await _dbContext.Wagers
                     .Where(w => bomberIds.Contains(w.Id))
                     .Select(w => w.Id)
                     .ToListAsync();

                var newWagers = wagers
                    .Where(w => !existingIds.Contains(w.Id))
                    .ToList();

                await _dbContext.Wagers.AddRangeAsync(newWagers);
                await _dbContext.SaveChangesAsync();

                _logger.LogDebug("[#] Inserting into DB done![#] ");
            }

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
