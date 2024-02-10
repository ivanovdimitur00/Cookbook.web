using Cookbook.Web.Models.Favourites;

namespace Cookbook.Business.Services.Favourites
{
    public interface IFavouritesService
    {
        IEnumerable<UserFavouritesViewModel> GetAllUserFavourites(string userId);

        bool AddToFavourites(string userId, string recipeId);

        void RemoveFromFavourites(Data.DataModels.Entities.Favourites favourites);

        Data.DataModels.Entities.Favourites FindFavourites(string userId, string recipeId);
    }
}
