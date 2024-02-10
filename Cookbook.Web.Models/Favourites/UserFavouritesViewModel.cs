using Cookbook.Web.Models.Recipes.ViewModels;

namespace Cookbook.Web.Models.Favourites
{
    public class UserFavouritesViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string UploaderUserName { get; set; }

        public RecipeConciseInformationViewModel RelatedRecipes { get; set; }
    }
}