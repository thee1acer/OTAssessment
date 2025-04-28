using Bogus;
using OT.Assessment.Api.Models;

namespace OT.Assessment.Tester.Services;
public class CasinoWagerBogusGenerator
{
    public CasinoWagerBogusGenerator() { }

    public List<WagerDTO> GenerateDummyWagers(int numberOfWagers)
    {  
        var providerFaker = new Faker<ProviderDTO>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Company.CompanyName());
        var providers = providerFaker.Generate(10);  

        var themeNames = new List<string>
        {
            "ancient",
            "adventure",
            "wildlife",
            "jungle",
            "retro",
            "family",
            "crash"
        };

        var themeFaker = new Faker<ThemeDTO>()
            .RuleFor(t => t.Id, f => Guid.NewGuid())
            .RuleFor(t => t.Name, f => f.PickRandom(themeNames));
        var themes = themeFaker.Generate(5); 

        var countryFaker = new Faker<CountryDTO>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Code, f => f.Address.CountryCode());
        var countries = countryFaker.Generate(5);

        var userFaker = new Faker<UserDTO>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Surname, f => f.Person.LastName)
            .RuleFor(u => u.UserName, f => f.Person.UserName)
            .RuleFor(u => u.Phone, f => f.Person.Phone)
            .RuleFor(u => u.Age, f => DateTime.Now.Year - f.Person.DateOfBirth.Year)
            .RuleFor(u => u.Email, f => f.Internet.Email());
        var users = userFaker.Generate(20);

        var transactionTypeFaker = new Faker<TransactionTypeDTO>()
            .RuleFor(t => t.Id, f => Guid.NewGuid())
            .RuleFor(t => t.Name, f => f.Random.Word())
            .RuleFor(t => t.Description, f => f.Rant.Review());
        var transactionsTypes = transactionTypeFaker.Generate(3);

        var transactionFaker = new Faker<TransactionDTO>()
            .RuleFor(t => t.Id, f => Guid.NewGuid())
            .RuleFor(t => t.Amount, f => f.Random.Double(5, 500))
            .RuleFor(t => t.NumberOfBets, f => f.Random.Number(5, 100))
            .RuleFor(t => t.CreatedDateTime, f => f.Date.Past(1))
            
            .RuleFor(t => t.User, f => f.PickRandom(users))
            .RuleFor(t => t.UserId, (f, t) => t.User.Id)

            .RuleFor(t => t.Type, f => f.PickRandom(transactionsTypes))
            .RuleFor(t => t.TransactionTypeId, (f, t) => t.Type.Id);
        var transactions = transactionFaker.Generate(50);

        var gameFaker = new Faker<GameDTO>()
            .RuleFor(g => g.Id, f => Guid.NewGuid())
            .RuleFor(g => g.Name, f => f.Commerce.ProductName())

            .RuleFor(g => g.Theme, f => f.PickRandom(themes))
            .RuleFor(g => g.ThemeId, (f, t) => t.Theme.Id)
            
            .RuleFor(g => g.Provider, f => f.PickRandom(providers))
            .RuleFor(g => g.ProviderId, (f, x) => x.Provider.Id);
        var games = gameFaker.Generate(20);

        var wagerFaker = new Faker<WagerDTO>()
            .RuleFor(w => w.Id, f => Guid.NewGuid())

            .RuleFor(w => w.Theme, f => f.PickRandom(themes).Name)
            .RuleFor(w => w.Provider, f => f.PickRandom(providers).Name)            
            .RuleFor(w => w.GameName, f => f.PickRandom(games).Name)
            
            .RuleFor(w => w.TransactionId, f =>  Guid.NewGuid())
            .RuleFor(w => w.BrandId, f => f.Random.Guid())
            .RuleFor(w => w.AccountId, f => f.Random.Guid())
            
            .RuleFor(w => w.UserName, f => f.Internet.UserName())

            .RuleFor(w => w.ExternalReferenceId, f => Guid.NewGuid())
            .RuleFor(w => w.TransactionTypeId, f => Guid.NewGuid())

            .RuleFor(w => w.Amount, f => f.Random.Double(1.0, 1000.0))
            
            .RuleFor(w => w.CreatedDateTime, f => f.Date.RecentOffset(days: 10).DateTime)
            
            .RuleFor(w => w.NumberOfBets, f => f.Random.Int(1, 10))
            .RuleFor(w => w.SessionData, f => f.Lorem.Sentence())
            .RuleFor(w => w.CountryCode, f => f.PickRandom(countries).Code)
            .RuleFor(w => w.Duration, f => f.Random.Long(1000, 5000));

        var wagers = wagerFaker.Generate(numberOfWagers);

        return wagers.DistinctBy(v => v.Id).ToList();
    }
}
