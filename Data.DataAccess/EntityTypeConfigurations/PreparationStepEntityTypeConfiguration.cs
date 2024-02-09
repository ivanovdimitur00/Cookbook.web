using Data.DataModels.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccess.EntityTypeConfigurations
{
    public class PreparationStepEntityTypeConfiguration : IEntityTypeConfiguration<PreparationStep>
    {
        public void Configure(EntityTypeBuilder<PreparationStep> entityTypeBuilder)
        {
            //is this correct?
            entityTypeBuilder
               .HasMany(l => l.PreparationStepsList)
               .WithOne(fp => fp.PreparationStep)
               .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}