using Data.DataModels.Entities;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal static class PreparationStepsListSeeder
    {
        internal static PreparationStepsList[] preparationStepsListSeedingArray { get; private set; } = SeedPreparationStepsLists();
        private static PreparationStepsList[] SeedPreparationStepsLists()
        {
            var preparationStepsListToSeed = new PreparationStepsList[]
                {
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[0].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[1].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[2].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[3].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[0].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[4].Id
                    },

                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[5].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[6].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[7].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[8].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[9].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[10].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[1].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[11].Id
                    },

                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[12].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[13].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[14].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[15].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[16].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[17].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[2].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[18].Id
                    },

                     new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[3].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[19].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[3].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[20].Id
                    },
                    new PreparationStepsList()
                    {
                       RecipeId = RecipeSeeder.recipeSeedingArray[3].Id,
                       PreparationStepId = PreparationStepSeeder.preparationStepSeedingArray[21].Id
                    }
                };

            return preparationStepsListToSeed;
        }
    }
}
