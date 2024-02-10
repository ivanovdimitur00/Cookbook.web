using Data.DataModels.Entities;

namespace Cookbook.Web.Models.Mapping
{
    public class AssignedRecipeIngredientsDataViewModel
    {
        public string RecipeIngredientId { get; set; }

        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string MeasurementId { get; set; }

        public virtual Measurement Measurement { get; set; }

        public string IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public bool IsAssigned { get; set; }
    }
}
