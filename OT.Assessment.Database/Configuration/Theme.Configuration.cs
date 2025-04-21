using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class ThemeConfiguration : IEntityTypeConfiguration<Theme>
{
    public void Configure(EntityTypeBuilder<Theme> builder)
    {
        builder.ToTable("Themes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired();

        var themesList = ThemesSeed();
        builder.HasData(themesList);

        builder.HasIndex(x => x.Name).IsUnique();
    }

    private static List<Theme> ThemesSeed()
    {
        var themes = new Dictionary<string, string>
        {
            { "b7a1a8fc-4f43-4b79-9c8d-2c3c8a3f87d0", "ancient" },
            { "e8d4d3ef-83b9-4c93-8d3e-6df56f20f1a1", "adventure" },
            { "f55dbdab-d29f-4f01-9c6d-56b3791fc2f7", "wildlife" },
            { "9fa0c14b-5392-4b49-a30f-e3b84e68cdcf", "jungle" },
            { "62d70655-06ee-4dd0-946d-086fa78b1cbb", "retro" },
            { "b19ef2b3-3d64-45b6-a6f2-c2d22c7a7cd4", "family" },
            { "c4b219c5-fbd9-4d62-a13d-f1b4eb19d9ec", "crash" }
        };

        List<Theme> themesList = new();

        foreach (var theme in themes)
        {
            themesList.Add
            (
                new Theme
                {
                    Id = Guid.Parse(theme.Key),
                    Name = theme.Value,
                }
            );
        }

        return themesList;
    }
}