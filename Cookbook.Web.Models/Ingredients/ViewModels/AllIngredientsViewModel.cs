using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using Cookbook.Web.Models.Recipes.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Web.Models.Ingredients.ViewModels
{
    public class AllIngredientsViewModel
    {
        public string Id { get; set; }

        [DisplayName(DisplayConstants.NameDisplayName)]
        public string Name { get; set; }

        public bool IsAllergen { get; set; }

        public IEnumerable<AssignedRecipeIngredientsDataViewModel>? AssignedRecipeIngredients { get; set; }
    }
}
