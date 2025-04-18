using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class GamePlayerConfiguration : IEntityTypeConfiguration<GamePlayer>
{
    public void Configure(EntityTypeBuilder<GamePlayer> builder)
    {
        builder.ToTable("GamePlayers");

        builder.Property(x => x.Age);
        builder.Property(x => x.Phone).IsRequired();

        builder.HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<ApplicationUser>("ApplicationUser")
            .HasValue<GamePlayer>("GamePlayer");
    }
}
