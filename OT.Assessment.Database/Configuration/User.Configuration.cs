using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.HasAlternateKey(u => u.UserName);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.Surname).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(u => u.Age).IsRequired();
        builder.Property(u => u.Phone).IsRequired();

        builder.HasOne(u => u.AccesLevel)
               .WithMany()
               .HasForeignKey(u => u.AccesLevelId)
               .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(u => u.Account)
               .WithOne(a => a.User)
               .HasForeignKey<User>(u => u.AccountId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
