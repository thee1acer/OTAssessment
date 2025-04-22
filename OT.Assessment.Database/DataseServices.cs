
using Microsoft.Extensions.DependencyInjection;
using OT.Assessment.Database.Services;

namespace OT.Assessment.Database;
public static class DatabaseServices
{
    public static void RegisterServices(this IServiceCollection service)
    {
        service.AddScoped<CasinoWagersService>();
    }
}

