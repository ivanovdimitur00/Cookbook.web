using Data.DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess.EntityTypeConfigurations
{
    public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> entityTypeBuilder)
        {
            //is this correct?
            entityTypeBuilder
               .HasMany(l => l.RecipeTags)
               .WithOne(fp => fp.Tag)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}