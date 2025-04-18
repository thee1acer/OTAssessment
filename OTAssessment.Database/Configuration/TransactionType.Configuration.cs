using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
{
    public void Configure(EntityTypeBuilder<TransactionType> builder)
    {
        builder.ToTable("TransactionTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.TransactionTypeName).IsRequired();
        builder.Property(x => x.TransactionTypeDescription).IsRequired();

        builder.HasIndex(x => x.TransactionTypeName).IsUnique(); 
    }
}
