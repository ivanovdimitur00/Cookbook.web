using Data.DataModels.Entities;

namespace Cookbook.Web.Models.Mapping
{
    public class AssignedRecipeTagsDataViewModel
    {
        public string RecipeTagId { get; set; }

        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public bool IsAssigned { get; set; }
    }
}
