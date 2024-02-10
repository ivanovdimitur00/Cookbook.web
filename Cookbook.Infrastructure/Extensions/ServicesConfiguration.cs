using Microsoft.Extensions.DependencyInjection;
//using SubtitlesManagementSystem.Business.Services.Actors;
//using SubtitlesManagementSystem.Business.Services.Comments;
//using SubtitlesManagementSystem.Business.Services.Countries;
//using SubtitlesManagementSystem.Business.Services.Directors;
//using SubtitlesManagementSystem.Business.Services.Favourites;
//using SubtitlesManagementSystem.Business.Services.FilmProductions;
//using SubtitlesManagementSystem.Business.Services.Genres;
//using SubtitlesManagementSystem.Business.Services.Languages;
//using SubtitlesManagementSystem.Business.Services.Screenwriters;
//using SubtitlesManagementSystem.Business.Services.Subtitles;
//using SubtitlesManagementSystem.Business.Services.SubtitlesCatalogue;
using Cookbook.Business.Services.Users;
using Cookbook.Business.Transactions.Implementation;
using Cookbook.Business.Transactions.Interfaces;

namespace Cookbook.Infrastructure.Extensions
{
    public static class ServicesConfiguration
    {
        public static void RegisterServiceLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            //serviceCollection.AddTransient<ICountryService, CountryService>();


            
            //serviceCollection.AddTransient<ICommentService, CommentService>();
            //serviceCollection.AddTransient<IFavouritesService, FavouritesService>();

            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}