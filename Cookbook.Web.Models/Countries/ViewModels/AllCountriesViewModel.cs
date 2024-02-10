using Cookbook.Web.Models.Recipes.ViewModels;

namespace Cookbook.Web.Models.Countries.ViewModels
{
    public class AllCountriesViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<RecipeConciseInformationViewModel> RelatedRecipes { get; set; }
    }
}
