using Cookbook.Common.GlobalConstants;
using Cookbook.Web.Models.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.Measurements.ViewModels
{
    public class AllMeasurementsViewModel
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        [DisplayName(DisplayConstants.UnitDisplayName)]
        public string Unit { get; set; }

        public IEnumerable<AssignedRecipeIngredientsDataViewModel>? AssignedRecipeIngredients { get; set; }
    }
}
