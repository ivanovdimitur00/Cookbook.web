using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Recipes.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cookbook.Web.Models.Recipes.ViewModels
{
    public class RecipeFullDetailsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        [DisplayName(DisplayConstants.CreatedByDisplayName)]
        public string CreatedBy { get; set; }

        [DisplayName(DisplayConstants.CreatedOnDisplayName)]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Country")]
        public string CountryName { get; set; }

        [DisplayName("Image")]
        public string ImageName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Preparation time")]
        public int PreparationTime { get; set; }

        public string PreparationTimeUnit { get; set; }

        [DisplayName("Servings")]
        public int Servings { get; set; }

        [DisplayName(DisplayConstants.ModifiedOnDisplayName)]
        [DisplayFormat(NullDisplayText = DisplayConstants.NullModifiedOnEntryDisplayName)]
        public DateTime? ModifiedOn { get; set; }

        [DisplayName(DisplayConstants.ModifiedByDisplayName)]
        [DisplayFormat(NullDisplayText = DisplayConstants.NullModifiedByEntryDisplayName)]
        public string ModifiedBy { get; set; }

        [DisplayName("Recipe Ingredients")]
        public List<Tuple<int, string, string>> RelatedRecipeIngredients { get; set; }

        [DisplayName("Preparation Steps")]
        public List<Tuple<int, string>> RelatedPreparationSteps { get; set; }

        [DisplayName("Recipe Tags")]
        public List<string> RelatedRecipeTags { get; set; }

    }
}
