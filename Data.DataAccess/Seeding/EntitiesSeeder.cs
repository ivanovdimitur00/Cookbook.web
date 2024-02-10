using Data.DataAccess.Seeding.PartialSeeders;
using Data.DataModels.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cookbook.Common.GlobalConstants;
using IdentityConstants = Cookbook.Common.GlobalConstants.IdentityConstants;

namespace Data.DataAccess.Seeding
{
    public class EntitiesSeeder : ISeeder
    {
        public async Task<bool> SeedDatabase(ApplicationDbContext applicationDbContext, IServiceProvider serviceProvider)
        {
            await ExecutePartialSeeders(applicationDbContext, serviceProvider);

            return true;
        }

        private async Task ExecutePartialSeeders(ApplicationDbContext applicationDbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var databaseLoadedUsers = applicationDbContext.Users.IgnoreQueryFilters().ToList();

            var administrator = databaseLoadedUsers
                .Where(dlu => dlu.ApplicationUserRoles
                    .Select(aur => aur.Role.Name).First() == IdentityConstants.AdministratorRoleName
                )
                .FirstOrDefault();

            foreach (var countryToSeed in CountrySeeder.countrySeedingArray)
            {
                countryToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.Countries.AddAsync(countryToSeed);
            }

            await applicationDbContext.SaveChangesAsync();

            foreach (var ingredinetToSeed in IngredientSeeder.ingredientSeedingArray)
            {
                ingredinetToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.Ingredients.AddAsync(ingredinetToSeed);
            }

            await applicationDbContext.SaveChangesAsync();

            foreach (var measurementToSeed in MeasurementSeeder.measurementSeedingArray)
            {
                measurementToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.Measurements.AddAsync(measurementToSeed);
            }

            await applicationDbContext.SaveChangesAsync();

            foreach (var preparationStepToSeed in PreparationStepSeeder.preparationStepSeedingArray)
            {
                preparationStepToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.PreparationSteps.AddAsync(preparationStepToSeed);
            }

            await applicationDbContext.SaveChangesAsync();

            foreach (var preparationStepsListToSeed in PreparationStepsListSeeder.preparationStepsListSeedingArray)
            {
                preparationStepsListToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.PreparationStepsList.AddAsync(preparationStepsListToSeed);
            }

            await applicationDbContext.SaveChangesAsync();

            foreach (var recipeIngredientsToSeed in RecipeIngredientsSeeder.recipeIngredientsSeedingArray)
            {
                recipeIngredientsToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.RecipeIngredients.AddAsync(recipeIngredientsToSeed);
            }

            await applicationDbContext.SaveChangesAsync();

            foreach (var recipeToSeed in RecipeSeeder.recipeSeedingArray)
            {
                recipeToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.Recipes.AddAsync(recipeToSeed);
            }

            await applicationDbContext.SaveChangesAsync();

            foreach (var recipeTagToSeed in RecipeTagSeeder.recipeTagSeedingArray)
            {
                recipeTagToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.RecipeTags.AddAsync(recipeTagToSeed);
            }

            await applicationDbContext.SaveChangesAsync();

            foreach (var tagToSeed in TagSeeder.tagSeedingArray)
            {
                tagToSeed.CreatedBy = administrator.UserName;
                await applicationDbContext.Tags.AddAsync(tagToSeed);
            }

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
