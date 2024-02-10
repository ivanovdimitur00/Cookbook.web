using Cookbook.Common.GlobalConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.PreparationSteps.ViewModels
{
    public class DeletePreparationStepViewModel
    {
        public int Number { get; set; }

        [DisplayName(DisplayConstants.DescriptionDisplayName)]
        public string Description { get; set; }
    }
}
