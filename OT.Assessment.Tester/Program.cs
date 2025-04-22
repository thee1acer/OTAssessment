using NBomber.CSharp;
using OT.Assessment.Api.Models;
using System.Text;
using System.Text.Json;

CasinoWagerBogusGenerator casinoWagerBogusGenerator = new();
List<WagerDTO> results = casinoWagerBogusGenerator.GenerateDummyWagers(10);

var scenario = 
    Scenario.Create("hello_world_scenario", async context =>
    {
        try
        {
            using var httpClient = new HttpClient();

            var body = JsonSerializer.Serialize(results);
            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("http://ot-assessment-api:5000/api/player/casinowager", content);

            if (response.IsSuccessStatusCode) return Response.Ok();
            return Response.Fail();
        }
        catch(HttpRequestException ex)
        {
            throw new HttpRequestException($"Failed processing http request with ex: {ex?.InnerException?.Message}");
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
    NBomberRunner
        .RegisterScenarios(scenario)
        .WithoutReports()
        .Run();
}
catch (Exception ex)
{ 
    Console.WriteLine($"NBomber failed with exception: {ex}");
}