using Cookbook.Web.Models.Countries.ViewModels;
using Cookbook.Web.Models.Recipes.ViewModels;
using System.ComponentModel;

namespace Cookbook.Web.Models.Recipes.ViewModels
{
    public class AllRecipesViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        [DisplayName("Country")]
        public CountryConciseInformationViewModel RelatedCountry { get; set; }
    }
}
