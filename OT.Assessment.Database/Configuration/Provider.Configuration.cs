using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");

            builder.HasKey(p => p.Id);
            builder.HasAlternateKey(p => p.Name);
            
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();

            builder.HasMany(p => p.Games)
                   .WithOne(g => g.Provider)
                   .HasForeignKey(g => g.ProviderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
