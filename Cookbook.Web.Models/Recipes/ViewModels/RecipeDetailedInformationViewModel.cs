using System.ComponentModel;

namespace Cookbook.Web.Models.Recipes.ViewModels
{
    public class RecipeDetailedInformationViewModel
    {
        public string Title { get; set; }

        [DisplayName("Servings")]
        public int Servings { get; set; }

        [DisplayName("Date of Creation")]
        public DateTime CreatedOn { get; set; }
    }
}
