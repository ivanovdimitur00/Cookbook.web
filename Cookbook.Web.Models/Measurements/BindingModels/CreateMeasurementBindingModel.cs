using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cookbook.Web.Models.Measurements.BindingModels
{
    public class CreateMeasurementBindingModel
    {
        [Required]
        [Range(0.05, 1000, ErrorMessage = ValidationConstants.MeasurementQuantityRangeValidationMessage)]
        public int? Quantity { get; set; } = null;

        [Required]
        [StringLength(20, MinimumLength = 1,
            ErrorMessage = ValidationConstants.MeasurementUnitMinimumLengthValidationMessage)]
        [DisplayName(DisplayConstants.UnitDisplayName)]
        public string Unit { get; set; }

        public IEnumerable<AssignedRecipeIngredientsDataViewModel>? AssignedRecipeIngredients { get; set; }
    }
}
