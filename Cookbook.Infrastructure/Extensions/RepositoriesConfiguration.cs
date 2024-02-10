using Data.DataAccess.Repositories.Implementation;
using Data.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Infrastructure.Extensions
{
    public static class RepositoriesConfiguration
    {
        public static void RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICountryRepository, CountryRepository>();
            serviceCollection.AddScoped<IIngredientRepository,IngredientRepository>();
            serviceCollection.AddScoped<IMeasurementRepository, MeasurementRepository>();
            serviceCollection.AddScoped<IPreparationStepRepository, PreparationStepRepository>();
            serviceCollection.AddScoped<IPreparationStepsListRepository, PreparationStepsListRepository>();
            serviceCollection.AddScoped<IRecipeIngredientsRepository, RecipeIngredientsRepository>();
            serviceCollection.AddScoped<IRecipeRepository, RecipeRepository>();
            serviceCollection.AddScoped<IRecipeTagRepository, RecipeTagRepository>();
            serviceCollection.AddScoped<ITagRepository, TagRepository>();
            serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
            serviceCollection.AddScoped<IFavouritesRepository, FavouritesRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
