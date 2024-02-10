using Data.DataModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModels.Entities
{
    public class PreparationStepsList : BaseEntity
    {
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string PreparationStepId { get; set; }

        public virtual PreparationStep PreparationStep { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
