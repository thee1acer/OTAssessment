using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers");

        builder.Property(x => x.AccessLevelId).IsRequired();

        builder.HasOne(x => x.AccesLevel)
               .WithMany()
               .HasForeignKey(x => x.AccessLevelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.AccessLevelId);
    }
}
