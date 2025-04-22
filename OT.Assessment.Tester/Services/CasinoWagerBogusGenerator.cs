using Bogus;
using OT.Assessment.Api.Models;
using OT.Assessment.Database.Models;

public class CasinoWagerBogusGenerator
{
    public CasinoWagerBogusGenerator() { }

    public List<WagerDTO> GenerateDummyWagers(int numberOfWagers)
    {
        var providerFaker = new Faker<ProviderDTO>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Company.CompanyName());
        var providers = providerFaker.Generate(10);  

        var themeFaker = new Faker<ThemeDTO>()
            .RuleFor(t => t.Id, f => Guid.NewGuid())
            .RuleFor(t => t.Name, f => f.Commerce.Department());
        var themes = themeFaker.Generate(5); 

        var countryFaker = new Faker<CountryDTO>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Code, f => f.Address.Country());
        var countries = countryFaker.Generate(5);

        var userFaker = new Faker<UserDTO>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Name, f => f.Person.FirstName)
            .RuleFor(u => u.Surname, f => f.Person.LastName)
            .RuleFor(u => u.UserName, f => f.Person.UserName)
            .RuleFor(u => u.Phone, f => f.Person.Phone)
            .RuleFor(u => u.Age, f => (DateTime.Now.Year - f.Person.DateOfBirth.Year))
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
            .RuleFor(w => w.SessionData, f => f.Lorem.Sentence())
            .RuleFor(w => w.Duration, f => f.Random.Long(1000, 5000))
            
            .RuleFor(w => w.Theme, f => f.PickRandom(themes))
            .RuleFor(w => w.ThemeId, (f, t) => t.Theme.Id)
            
            .RuleFor(w => w.Provider, f => f.PickRandom(providers))
            .RuleFor(w => w.ProviderId, (f, t) => t.Provider.Id)

            .RuleFor(w => w.Game, f => f.PickRandom(games))
            .RuleFor(w => w.GameId, (f, t) => t.Game.Id)
            
            .RuleFor(w => w.Transaction, f => f.PickRandom(transactions))
            .RuleFor(w => w.TransactionId, (f, t) => t.Transaction.Id)

            .RuleFor(w => w.Country, f => f.PickRandom(countries))
            .RuleFor(w => w.CountryId, (f, t) => t.Country.Id);
        var wagers = wagerFaker.Generate(numberOfWagers);

        return wagers;
    }
}
