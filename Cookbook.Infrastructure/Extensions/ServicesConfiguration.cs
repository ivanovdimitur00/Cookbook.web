using Microsoft.Extensions.DependencyInjection;
using Cookbook.Business.Services.Ingredients;
using Cookbook.Business.Services.Comments;
using Cookbook.Business.Services.Countries;
using Cookbook.Business.Services.Favourites;
using Cookbook.Business.Services.PreparationSteps;
using Cookbook.Business.Services.Recipes;
using Cookbook.Business.Services.Tags;
using Cookbook.Business.Services.Users;
using Cookbook.Business.Transactions.Implementation;
using Cookbook.Business.Transactions.Interfaces;
using Cookbook.Business.Services.Measurements;

namespace Cookbook.Infrastructure.Extensions
{
    public static class ServicesConfiguration
    {
        public static void RegisterServiceLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient<IIngredientService, IngredientService>();
            serviceCollection.AddTransient<IMeasurementService, MeasurementService>();
            serviceCollection.AddTransient<IPreparationStepService, PreparationStepService>();
            serviceCollection.AddTransient<ICountryService, CountryService>();
            serviceCollection.AddTransient<IRecipeService, RecipeService>();
            serviceCollection.AddTransient<ITagService, TagService>();
            serviceCollection.AddTransient<ICommentService, CommentService>();
            serviceCollection.AddTransient<IFavouritesService, FavouritesService>();
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}