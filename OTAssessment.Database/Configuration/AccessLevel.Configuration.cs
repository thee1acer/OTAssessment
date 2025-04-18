using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OT.Assessment.Database.Enums;
using OT.Assessment.Database.Models;

namespace OT.Assessment.Database.Configurations;

public class AccessLevelConfiguration : IEntityTypeConfiguration<AccessLevel>
{
    public void Configure(EntityTypeBuilder<AccessLevel> builder)
    {
        builder.ToTable("AccessLevels");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValue("NEWID()").ValueGeneratedOnAdd();

        builder.HasData(
            new AccessLevel 
            { 
                Id = Guid.NewGuid(),
                AccesType = AccessLevelEnum.Administrator.ToString(), 
                AccessDescription =  AccessLevelEnum.Administrator.Description()
            },
            new AccessLevel 
            { 
                Id = Guid.NewGuid(),
                AccesType = AccessLevelEnum.Developer.ToString(),
                AccessDescription =  AccessLevelEnum.Developer.Description()
            },
            new AccessLevel 
            {
                Id = Guid.NewGuid(),
                AccesType = AccessLevelEnum.QaTester.ToString(),
                AccessDescription =  AccessLevelEnum.QaTester.Description()
            }
        );
    }
}
