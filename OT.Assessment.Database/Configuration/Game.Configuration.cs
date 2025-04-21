using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id).ValueGeneratedOnAdd();
            builder.Property(g => g.Name).IsRequired();

            builder.HasOne(g => g.Provider)
                   .WithMany(p => p.Games)
                   .HasForeignKey(g => g.ProviderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.Theme)
                   .WithMany()
                   .HasForeignKey(g => g.ThemeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
