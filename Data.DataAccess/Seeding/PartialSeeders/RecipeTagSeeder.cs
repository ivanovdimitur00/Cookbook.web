using Data.DataModels.Entities;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal static class RecipeTagSeeder
    {
        internal static RecipeTag[] recipeTagSeedingArray { get; private set; } = SeedRecipeTags();

        private static RecipeTag[] SeedRecipeTags()
        {
            var recipeTagsToSeed = new RecipeTag[]
                {
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                        TagId = TagSeeder.tagSeedingArray[0].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                        TagId = TagSeeder.tagSeedingArray[1].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                        TagId = TagSeeder.tagSeedingArray[2].Id
                    },

                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                        TagId = TagSeeder.tagSeedingArray[3].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                        TagId = TagSeeder.tagSeedingArray[4].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                        TagId = TagSeeder.tagSeedingArray[5].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                        TagId = TagSeeder.tagSeedingArray[6].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                        TagId = TagSeeder.tagSeedingArray[7].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                        TagId = TagSeeder.tagSeedingArray[8].Id
                    },

                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                        TagId = TagSeeder.tagSeedingArray[3].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                        TagId = TagSeeder.tagSeedingArray[4].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                        TagId = TagSeeder.tagSeedingArray[5].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                        TagId = TagSeeder.tagSeedingArray[6].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                        TagId = TagSeeder.tagSeedingArray[7].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                        TagId = TagSeeder.tagSeedingArray[8].Id
                    },

                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[3].Id,
                        TagId = TagSeeder.tagSeedingArray[2].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[3].Id,
                        TagId = TagSeeder.tagSeedingArray[7].Id
                    },
                    new RecipeTag()
                    {
                        RecipeId = RecipeSeeder.recipeSeedingArray[3].Id,
                        TagId = TagSeeder.tagSeedingArray[8].Id
                    },
                };
            return recipeTagsToSeed;
        }
    }
}
