﻿using Data.DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DataAccess.EntityTypeConfigurations
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entityTypeBuilder)
        {
            entityTypeBuilder
               .HasMany(c => c.Recipes)
               .WithOne(r => r.Country)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
