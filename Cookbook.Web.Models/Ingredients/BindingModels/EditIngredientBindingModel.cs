using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cookbook.Web.Models.Ingredients.BindingModels
{
    public class EditIngredientBindingModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = ValidationConstants.IngredientNameMinimumLengthValidationMessage)]
        [DisplayName(DisplayConstants.NameDisplayName)]
        public string Name { get; set; }

        [Required]
        public bool IsAllergen { get; set; }

        public IEnumerable<AssignedRecipeIngredientsDataViewModel>? AssignedRecipeIngredients { get; set; }
    }
}
