using Cookbook.Web.Models.Recipes.ViewModels;

namespace Cookbook.Web.Models.Recipes.ViewModels
{
    public class AllRecipesViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public RecipeConciseInformationViewModel RelatedRecipes { get; set; }
    }
}
