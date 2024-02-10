using Data.DataModels.Entities;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal static class RecipeIngredientsSeeder
    {
        internal static RecipeIngredients[] recipeIngredientsSeedingArray { get; private set; } = SeedRecipeIngredients();
        private static RecipeIngredients[] SeedRecipeIngredients()
        {
            var recipeIngredientsToSeed = new RecipeIngredients[]
                {
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[0].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[0].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[1].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[1].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[2].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[2].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[2].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[3].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[3].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[4].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[4].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[5].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[6].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[5].Id
                    },

                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[6].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[7].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[0].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[8].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[0].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[9].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[8].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[3].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[7].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[5].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[9].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[10].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[10].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[11].Id
                    },

                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[6].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[12].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[0].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[8].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[0].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[9].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[8].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[3].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[7].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[5].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[9].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[10].Id
                    },

                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[3].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[11].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[0].Id
                    },
                    new RecipeIngredients()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[3].Id,
                       MeasurementId = MeasurementSeeder.measurementSeedingArray[12].Id,
                       IngredientId = IngredientSeeder.ingredientSeedingArray[13].Id
                    }
                };

            return recipeIngredientsToSeed;
        }
    }
}
