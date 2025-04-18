using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.AccountBalance).IsRequired();

        builder.HasOne(x => x.User).WithOne().HasForeignKey<Account>(x => x.UserId);
    }
}
