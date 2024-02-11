using Data.DataModels.Entities;
using System.ComponentModel.DataAnnotations;

namespace Cookbook.Web.Models.Mapping
{
    public class AssignedPreparationStepsListDataViewModel
    {
        public string PreparationStepsListId { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public bool IsAssigned { get; set; }
    }
}
