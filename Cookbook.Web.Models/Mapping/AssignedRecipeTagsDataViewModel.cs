using Data.DataModels.Entities;

namespace Cookbook.Web.Models.Mapping
{
    public class AssignedRecipeTagsDataViewModel
    {
        public string RecipeTagId { get; set; }

        public string Name { get; set; }

        public bool IsAssigned { get; set; }
    }
}
