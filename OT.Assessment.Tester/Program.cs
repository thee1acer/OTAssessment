using Microsoft.AspNetCore.Http;
using NBomber.CSharp;
using OT.Assessment.Api.Models;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;


CasinoWagerBogusGenerator casinoWagerBogusGenerator = new();
List<WagerDTO> results = casinoWagerBogusGenerator.GenerateDummyWagers(10);

using var httpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(10) };

httpClient.DefaultRequestHeaders.Connection.Clear();
httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");

var scenario =
    Scenario.Create("casino_wager_scenario", async context =>
    {
        try
        {
            var body = JsonSerializer.Serialize(results);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://ot-assessment-api:5000/api/player/casinowager", content);

            return response.IsSuccessStatusCode ? Response.Ok() : Response.Fail();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed connecting to api endpoint with exc: {ex}");
            return Response.Fail();
        }
    })
    .WithoutWarmUp()
    .WithLoadSimulations
    (
        Simulation.IterationsForInject(
            rate: 500,
            interval: TimeSpan.FromSeconds(2),
            iterations: 7000
        )
    );

try
{
    Console.WriteLine($"Starting NBomberRunner");

    NBomberRunner
        .RegisterScenarios(scenario)
        .WithoutReports()
        .Run();
}
catch (Exception ex)
{
    Console.WriteLine($"NBomber failed with exception: {ex}");
}
