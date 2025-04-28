using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NBomber.CSharp;
using OT.Assessment.Api.Models;
using System.Text;
using System.Text.Json;
using DotNetEnv;

namespace OT.Assessment.Tester.Services;

public class NbomberService : BackgroundService
{
    private ILogger<NbomberService> _logger;
    private CasinoWagerBogusGenerator _casinoWagerBogusGenerator;

    public NbomberService(CasinoWagerBogusGenerator casinoWagerBogusGenerator, ILogger<NbomberService> logger)
    {
        _casinoWagerBogusGenerator = casinoWagerBogusGenerator;
        _logger = logger;
    }

    public List<WagerDTO> GenerateFakeResults()
    {
        return  _casinoWagerBogusGenerator.GenerateDummyWagers(1000);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {   
        Env.Load();

        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2),
            PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1),
            MaxConnectionsPerServer = int.MaxValue
        };

        using var httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromMinutes(1000)
        };

        httpClient.DefaultRequestHeaders.Connection.Clear();
        httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");

        _logger.LogDebug("Client setup and creating scenarios");

        var scenario =
            Scenario.Create("casino_wager_scenario", async context =>
            {
                try
                {
                    List<WagerDTO> results = GenerateFakeResults();

                    var body = JsonSerializer.Serialize(results);
                    var content = new StringContent(body, Encoding.UTF8, "application/json");

                    var response = 
                        await httpClient.PostAsync
                        (
                            "http://ot-assessment-api:5000/api/player/casinowager",
                            content
                        );
                    
                    if(response.IsSuccessStatusCode) return Response.Ok();

                    _logger.LogInformation($"[#] Failed to perform a post request with results {response}[#]");                
                    
                    return Response.Fail();
                }
                catch (Exception ex)
                {
                    _logger.LogDebug($"Failed connecting to api endpoint with exc: {ex}");
                    return Response.Fail();
                }
            })
            .WithoutWarmUp()
            .WithLoadSimulations
            (
                Simulation.IterationsForInject
                (
                    rate: 500,
                    interval: TimeSpan.FromSeconds(2),
                    iterations: 7000
                )
            );

        try
        {
            _logger.LogInformation($"Starting NBomberRunner");

            NBomberRunner
                .RegisterScenarios(scenario)
                .WithoutReports()
                .Run();

            _logger.LogInformation($"NBomberRunner Finished successfully");
        }
        catch (Exception ex)
        {
            _logger.LogDebug($"NBomber failed with exception: {ex}");
        }
    }
}