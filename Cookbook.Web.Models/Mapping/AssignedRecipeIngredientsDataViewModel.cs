using Data.DataModels.Entities;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Web.Models.Mapping
{
    public class AssignedRecipeIngredientsDataViewModel
    {
        public string RecipeIngredientId { get; set; }

        public string Name { get; set; }

        public bool IsAllergen { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public bool IsAssigned { get; set; }
    }
}
