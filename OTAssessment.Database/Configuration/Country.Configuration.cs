using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(x => x.Code);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Code).IsRequired();
    }
}
