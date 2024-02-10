using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.Measurements.BindingModels
{
    public class EditMeasurementBindingModel
    {
        public string Id { get; set; }

        [Required]
        [Range(0.05, 1000, ErrorMessage = ValidationConstants.MeasurementQuantityRangeValidationMessage)]
        public int Quantity { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1,
            ErrorMessage = ValidationConstants.MeasurementUnitMinimumLengthValidationMessage)]
        [DisplayName(DisplayConstants.UnitDisplayName)]
        public string Unit { get; set; }

        public IEnumerable<AssignedRecipeIngredientsDataViewModel>? AssignedRecipeIngredients { get; set; }
    }
}
