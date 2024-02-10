using Cookbook.Common.GlobalConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.Measurements.ViewModels
{
    public class DeleteMeasurementsViewModel
    {
        public int Quantity { get; set; }

        [DisplayName(DisplayConstants.UnitDisplayName)]
        public string Unit { get; set; }
    }
}
