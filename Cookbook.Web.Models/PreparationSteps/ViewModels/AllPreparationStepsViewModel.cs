using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.PreparationSteps.ViewModels
{
    public class AllPreparationStepsViewModel
    {
        public string Id { get; set; }

        public int Number { get; set; }

        [DisplayName(DisplayConstants.DescriptionDisplayName)]
        public string Description { get; set; }

        public IEnumerable<AssignedPreparationStepsListDataViewModel>? AssignedPreparationStepsList { get; set; }
    }
}
