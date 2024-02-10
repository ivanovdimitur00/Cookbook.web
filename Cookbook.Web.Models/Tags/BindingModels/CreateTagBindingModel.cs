using Cookbook.Common.GlobalConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Web.Models.Mapping;

namespace Cookbook.Web.Models.Tags.BindingModels
{
    public class CreateTagBindingModel
    {
        [Required]
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = ValidationConstants.TagNameMinimumLengthValidationMessage)]
        [DisplayName(DisplayConstants.NameDisplayName)]
        public string Name { get; set; }

        public IEnumerable<AssignedRecipeTagsDataViewModel>? AssignedRecipeTags { get; set; }
    }
}
