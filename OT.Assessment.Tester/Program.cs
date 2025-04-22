using NBomber.CSharp;
using NBomber.Http;
using NBomber.Http.CSharp;
using NBomber.Plugins.Network.Ping;
using System.Text;
using System.Text.Json;

CasinoWagerBogusGenerator casinoWagerBogusGenerator = new();

var results = casinoWagerBogusGenerator.GenerateDummyWagers(10);
var body = JsonSerializer.Serialize(results);

using var httpClient = new HttpClient();

var scenario = 
    Scenario.Create("hello_world_scenario", async context =>
    {
        try
        {
            var request =
                Http.CreateRequest("POST", "https://ot-assessment-api:5000/api/player/casinowager")
                    .WithBody(new StringContent(body, Encoding.UTF8, "application/json"));

            var response = await Http.Send(httpClient, request);

            if (response.StatusCode == "OK") return Response.Ok();

            Console.WriteLine($"Request failed with status: {response.StatusCode}, Message: {response.Message}");

            return
                Response.Fail
                (
                    body,
                    response.StatusCode,
                    response.Message,
                    response.SizeBytes
                );
        }
        catch(Exception ex)
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
        .Run();
}
catch (Exception ex)
{ 
    Console.WriteLine($"NBomber failed with exception: {ex}");
}