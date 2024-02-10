using Cookbook.Common.GlobalConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.Ingredients.ViewModels
{
    public class DeleteIngredientViewModel
    {
        [DisplayName(DisplayConstants.NameDisplayName)]
        public string Name { get; set; }

        public bool IsAllergen { get; set; }
    }
}
