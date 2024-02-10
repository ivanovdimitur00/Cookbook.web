using Cookbook.Common.GlobalConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Web.Models.Tags.ViewModels
{
    public class TagConciseInformationViewModel
    {
        [DisplayName(DisplayConstants.NameDisplayName)]
        public string Name { get; set; }
    }
}
