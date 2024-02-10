using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cookbook.Web.Models.Recipes.BindingModels
{
    public class EditRecipeBindingModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = ValidationConstants.RecipeTitleMinimumLengthValidationMessage)]
        public string Title { get; set; }

        public string CountryId { get; set; }

        [Required]
        [DisplayName(DisplayConstants.RecipeCreationDateDisplayName)]
        public DateTime? CreatedOn { get; set; } = null;

        [DisplayName("Upload Image")]
        public IFormFile? ImageFile { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 20,
                ErrorMessage = ValidationConstants.RecipeDescriptionMinimumLengthValidationMessage)]
        [DisplayName(DisplayConstants.RecipeDescriptionDisplayName)]
        public string Description { get; set; }

        [Required]
        [Range(5, 720, ErrorMessage = ValidationConstants.RecipePreparationtimeRangeValidationMessage)]
        public int? PreparationTime { get; set; } = null;

        [Required]
        [StringLength(16, MinimumLength = 1,
            ErrorMessage = ValidationConstants.RecipePreparationTimeUnitMinimumLengthValidationMessage)]
        public string PreparationTimeUnit { get; set; }

        [Required]
        [Range(1, 24, ErrorMessage = ValidationConstants.RecipeServingsRangeValidationMessage)]
        public int? Servings { get; set; } = null;

        public IEnumerable<AssignedRecipeIngredientsDataViewModel>? AssignedRecipeIngredients { get; set; }

        public IEnumerable<AssignedPreparationStepsListDataViewModel>? AssignedPreparationStepsLists { get; set; }

        public IEnumerable<AssignedRecipeTagsDataViewModel>? AssignedRecipeTags { get; set; }
    }
}
