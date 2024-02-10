using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cookbook.Web.Models.PreparationSteps.BindingModels
{
    public class CreatePreprationStepsBindingModel
    {
        [Required]
        [Range(1, 24, ErrorMessage = ValidationConstants.PreparationStepNumberRangeValidationMessage)]
        public int Number { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 20,
            ErrorMessage = ValidationConstants.PreparationStepDescriptionMaximumLengthValidationMessage)]
        [DisplayName(DisplayConstants.UnitDisplayName)]
        public string Description { get; set; }

        public IEnumerable<AssignedPreparationStepsListDataViewModel>? AssignedPreparationStepsList { get; set; }
    }
}
