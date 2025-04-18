using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class WagerConfiguration : IEntityTypeConfiguration<Wager>
{
    public void Configure(EntityTypeBuilder<Wager> builder)
    {
        builder.ToTable("Wagers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.SessionData).IsRequired();
        builder.Property(x => x.Duration).IsRequired();

        builder.Property(x => x.ThemeId).IsRequired();
        builder.HasOne(x => x.Theme)
               .WithMany() 
               .HasForeignKey(x => x.ThemeId)
               .OnDelete(DeleteBehavior.Restrict);

        
        builder.Property(x => x.ProviderId).IsRequired();

        builder.HasOne(x => x.Provider)
               .WithMany()
               .HasForeignKey(x => x.ProviderId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.GameId).IsRequired();
        builder.HasOne(x => x.Game)
               .WithMany()
               .HasForeignKey(x => x.GameId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.TransactionId).IsRequired();
        builder.HasOne(x => x.Transaction)
               .WithMany()
               .HasForeignKey(x => x.TransactionId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.CountryId).IsRequired();
        builder.HasOne(x => x.Country)
               .WithMany()
               .HasForeignKey(x => x.CountryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.GameId);
        builder.HasIndex(x => x.TransactionId);
        builder.HasIndex(x => x.CountryId);
    }
}
