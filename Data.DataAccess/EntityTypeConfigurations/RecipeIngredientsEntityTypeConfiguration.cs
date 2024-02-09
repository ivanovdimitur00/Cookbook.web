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
    internal class RecipeIngredientsEntityTypeConfiguration : IEntityTypeConfiguration<RecipeIngredients>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredients> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(ri => new { ri.RecipeId, ri.MeasurementId, ri.IngredientId });
            entityTypeBuilder
                .HasOne(ri => ri.Recipe)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);
            entityTypeBuilder
                .HasOne(ri => ri.Measurement)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(ri => ri.MeasurementId);
            entityTypeBuilder
                .HasOne(ri => ri.Ingredient)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);
        }
    }
}
