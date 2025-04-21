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

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Description).IsRequired();

        builder.HasData(
            new AccessLevel 
            { 
                Id = Guid.Parse("9a3e8e9d-2b6d-4f6a-a5bb-5d4cd51c27ab"),
                Type = AccessLevelEnum.Administrator.ToString(), 
                Description =  AccessLevelEnum.Administrator.Description()
            },
            new AccessLevel 
            { 
                Id = Guid.Parse("e4c77b0d-b1ce-49d2-80f2-c52971b6b905"),
                Type = AccessLevelEnum.Developer.ToString(),
                Description =  AccessLevelEnum.Developer.Description()
            },
            new AccessLevel 
            {
                Id = Guid.Parse("2077cfaa-7b5d-4d6f-85d7-c76e940f6971"),
                Type = AccessLevelEnum.QaTester.ToString(),
                Description =  AccessLevelEnum.QaTester.Description()
            }
        );
    }
}
