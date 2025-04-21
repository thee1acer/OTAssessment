using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.Balance).IsRequired();

        builder.HasOne(a => a.User)
               .WithOne(u => u.Account)
               .HasForeignKey<Account>(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
