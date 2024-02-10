using Data.DataModels.Entities;

namespace Cookbook.Web.Models.Mapping
{
    public class AssignedPreparationStepsListDataViewModel
    {
        public string PreparationStepsListId { get; set; }

        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string PreparationStepId { get; set; }

        public virtual PreparationStep PreparationStep { get; set; }
        
        public bool IsAssigned { get; set; }
    }
}
