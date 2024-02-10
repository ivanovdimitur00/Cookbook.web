using Cookbook.Common.GlobalConstants;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Web.Models.Countries.BindingModels
{
    public class EditCountryBindingModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2,
            ErrorMessage = ValidationConstants.CountryNameMinimumLengthValidationMessage)]
        public string Name { get; set; }
    }
}
