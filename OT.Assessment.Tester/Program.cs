using System.Text;
using System.Text.Json;
using NBomber.CSharp;
using NBomber.Http;
using NBomber.Http.CSharp;

CasinoWagerBogusGenerator casinoWagerBogusGenerator = new();
var results = casinoWagerBogusGenerator.GenerateDummyWagers(10);

var scenario = Scenario.Create("hello_world_scenario", 
        async context =>
        {
            var body = JsonSerializer.Serialize(results);
            using var httpClient = new HttpClient();
            
            var request =
                Http.CreateRequest("POST", "https://localhost:5000/api/player/casinowager")
                    .WithHeader("Accept", "application/json")
                    .WithBody
                    (
                        new StringContent
                        (
                            $"{body}", 
                            Encoding.UTF8, 
                            "application/json"
                        )
                    );

            var response = await Http.Send(httpClient, request);

            if (response.StatusCode == "OK")
                return Response.Ok();

            return Response.Fail
                    (
                        body,
                        response.StatusCode,
                        response.Message,
                        response.SizeBytes
                    );
        }
     )
    .WithoutWarmUp()
    .WithLoadSimulations(
        Simulation.IterationsForInject
        (
            rate: 500,
            interval: TimeSpan.FromSeconds(2),
            iterations: 7000
        )
    );

NBomberRunner
    .RegisterScenarios(scenario)
        .WithWorkerPlugins
        (
            new HttpMetricsPlugin(
                new[] 
                { 
                    NBomber.Http.HttpVersion.Version1 
                }
            )
        )
        .WithoutReports()
    .Run();