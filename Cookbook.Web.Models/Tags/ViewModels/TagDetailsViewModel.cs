using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.Tags.ViewModels
{
    public class TagDetailsViewModel
    {
        public string Id { get; set; }

        [DisplayName(DisplayConstants.NameDisplayName)]
        public string Name { get; set; }

        [DisplayName(DisplayConstants.CreatedOnDisplayName)]
        public DateTime CreatedOn { get; set; }

        [DisplayName(DisplayConstants.CreatedByDisplayName)]
        public string CreatedBy { get; set; }

        [DisplayName(DisplayConstants.ModifiedOnDisplayName)]
        [DisplayFormat(NullDisplayText = DisplayConstants.NullModifiedOnEntryDisplayName)]
        public DateTime? ModifiedOn { get; set; }

        [DisplayName(DisplayConstants.ModifiedByDisplayName)]
        [DisplayFormat(NullDisplayText = DisplayConstants.NullModifiedByEntryDisplayName)]
        public string ModifiedBy { get; set; }

        public IEnumerable<AssignedRecipeTagsDataViewModel>? AssignedRecipeTags { get; set; }
    }
}
