using Bogus;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OT.Assessment.Database;
using OT.Assessment.Models;
using System.Numerics;

namespace OT.Assessment.Api.Services;
public class CasinoWagerBogusGenerator
{

    //private readonly Faker<WagerDTO> _testCasinoWagerFaker;
    private OTAssessmentContext _dbcontext;
    private ILogger<CasinoWagerBogusGenerator> _logger;

    public CasinoWagerBogusGenerator(){}

    public CasinoWagerBogusGenerator(OTAssessmentContext dbContext, ILogger<CasinoWagerBogusGenerator> logger)
    {
        _dbcontext = dbContext;
        _logger = logger;
    }

    public async Task<List<WagerDTO>> GenerateMocksAsync(int numberOfCasinoWagers)
    {
        Randomizer.Seed = new Random(1010);

        var themes = await _dbcontext.Themes.ToListAsync();
        var mappedThemes = themes.Adapt<List<ThemeDTO>>();

        var testPlayers = new Faker<GamePlayerDTO>()
           .StrictMode(true)
                .RuleFor(o => o.Name, f => f.Person.FirstName)
                .RuleFor(o => o.Surname, f => f.Person.LastName)
                .RuleFor(o => o.UserName, f => f.Person.UserName)
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.Age, f => f.Random.Int(18, 65))
                .RuleFor
                (
                    o => o.Account,
                        f => 
                            new Faker<AccountDTO>()
                                .StrictMode(true)
                                    .RuleFor(of => of.AccountBalance, f => f.Random.Int(18, 65))
                                .Generate(10)
                )
                .RuleFor(o => o.AccountId, f => f.Random.Guid()).Generate(1000)
           .Generate(1000);

        var testProviders = new Faker<ProviderDTO>()
           .StrictMode(true)
                .RuleFor(o => o.Name, f => f.Commerce.ProductName())
                .RuleFor
                (
                    o => o.Games, 
                        f =>
                            new Faker<GameDTO>()
                                .StrictMode(true)
                                    .RuleFor(of => of.Name, f => f.Commerce.ProductName())
                                    .RuleFor(of => of.Theme, f => f.PickRandom(mappedThemes))
                                    .RuleFor(of => of.ThemeName, (f, of) => of.Theme.Name)
                                .Generate(10)
                )
           .Generate(100);
        
        _testCasinoWagerFaker = new Faker<WagerDTO>()
            .StrictMode(true)
            .RuleFor(o => o.SessionData, f => f.Random.Words(20))
            .RuleFor(o => o.WagerId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.Provider, (f, u) => f.PickRandom(testProviders).Name)
            .RuleFor(o => o.GameName, (f, u) => f.PickRandom(testProviders.First(x => x.Name == u.Provider).Games).Name)
            .RuleFor(o => o.Theme,
                (f, u) => f.PickRandom(testProviders.First(x => x.Name == u.Provider).Games
                    .First(x => x.Name == u.GameName)).Theme)
            .RuleFor(o => o.TransactionId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.BrandId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.Username, f => f.PickRandom(testPlayers).Username.ToString())
            .RuleFor(o => o.AccountId,
                (f, u) => f.PickRandom(testPlayers.First(x => x.Username == u.Username)).AccountId.ToString())
            .RuleFor(o => o.ExternalReferenceId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.TransactionTypeId, () => Guid.NewGuid().ToString())
            .RuleFor(o => o.CreatedDateTime, f => f.Date.Past())
            .RuleFor(o => o.NumberOfBets, f => f.Random.Int(1, 10))
            .RuleFor(o => o.CountryCode, f => f.Address.CountryCode())
            .RuleFor(o => o.Duration, f => f.Random.Long(10000, 3600000)).RuleFor(o => o.Amount, f => f.Random.Double(10, 50000));

        return new List<WagerDTO>();
    }
}