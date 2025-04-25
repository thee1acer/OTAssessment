using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configuration;

public class WagerConfiguration : IEntityTypeConfiguration<Wager>
{
    public void Configure(EntityTypeBuilder<Wager> builder)
    {
        builder.ToTable("Wagers");

        builder.HasKey(w => w.Id);

        builder.HasAlternateKey(w => new
        {
            w.TransactionId,
            w.ExternalReferenceId
        });

        builder.Property(w => w.Id).IsRequired();
        builder.Property(w => w.Theme).IsRequired().HasMaxLength(100);
        builder.Property(w => w.Provider).IsRequired().HasMaxLength(100);
        builder.Property(w => w.GameName).IsRequired().HasMaxLength(100);
        builder.Property(w => w.TransactionId).IsRequired();
        builder.Property(w => w.BrandId).IsRequired();
        builder.Property(w => w.AccountId).IsRequired();
        builder.Property(w => w.UserName).IsRequired().HasMaxLength(100);
        builder.Property(w => w.ExternalReferenceId).IsRequired();
        builder.Property(w => w.TransactionTypeId).IsRequired();
        builder.Property(w => w.Amount).IsRequired().HasPrecision(18, 2);
        builder.Property(w => w.CreatedDateTime).IsRequired();
        builder.Property(w => w.NumberOfBets).IsRequired();
        builder.Property(w => w.CountryCode).IsRequired().HasMaxLength(5);
        builder.Property(w => w.SessionData).IsRequired().HasMaxLength(500);
        builder.Property(w => w.Duration).IsRequired();

        builder.HasIndex(w => w.TransactionId);
        builder.HasIndex(w => w.AccountId);
    }
}
