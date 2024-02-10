using Cookbook.Common.GlobalConstants;
using Data.DataModels.Entities;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Data.DataAccess.Seeding.PartialSeeders
{
    internal class RecipeSeeder
    {
        internal static Recipe[] recipeSeedingArray { get; private set; } = SeedRecipes();

        private static Recipe[] SeedRecipes()
        {
            var recipesToSeed = new Recipe[]
                {
                    new Recipe()
                    {
                        Title = "Banana bread",
                        CreatedBy = IdentityConstants.AdministratorUsername,
                        ImageName = "Banana bread",
                        CountryId = CountrySeeder.CountrySeedingArray
                        .Single(c => c.Name == "Germany").Id,
                        Description = "Tasty banana bread. Not too sweet. Ideal for breakfast. Very filling.",
                        PreparationTime = 1,
                        PreparationTimeUnit = "Hour",
                        Servings = 5
                    },
                    new Recipe()
                    {
                        Title = "Beans stew",
                        CreatedBy = IdentityConstants.AdministratorUsername,
                        ImageName = "Beans stew",
                        CountryId = CountrySeeder.CountrySeedingArray
                        .Single(c => c.Name == "Bulgaria").Id,
                        Description = "Beans stew. Feeds the whole family. Favourite lunch for the Bulgarians.",
                        PreparationTime = 2,
                        PreparationTimeUnit = "Hours",
                        Servings = 12
                    },
                    new Recipe()
                    {
                        Title = "Lentils soup",
                        CreatedBy = IdentityConstants.UploaderUsername,
                        ImageName = "Lentils stew",
                        CountryId = CountrySeeder.CountrySeedingArray
                        .Single(c => c.Name == "Bulgaria").Id,
                        Description = "Lenitls soup. Feeds the whole family. Favourite lunch for the Bulgarians.",
                        PreparationTime = 90,
                        PreparationTimeUnit = "Minutes",
                        Servings = 12
                    },
                    new Recipe()
                    {
                        Title = "Scrambled eggs",
                        CreatedBy = IdentityConstants.AdministratorUsername,
                        ImageName = "Scrambled eggs",
                        CountryId = CountrySeeder.CountrySeedingArray
                        .Single(c => c.Name == "Spain").Id,
                        Description = "Scrambled eggs with white cheese. For when you have little time to cook. very filling.",
                        PreparationTime = 20,
                        PreparationTimeUnit = "Minutes",
                        Servings = 2
                    },
                };
            return recipesToSeed;
        }
    }
}
