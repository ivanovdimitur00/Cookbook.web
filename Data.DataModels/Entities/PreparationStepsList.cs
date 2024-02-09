using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModels.Entities
{
    public class PreparationStepsList
    {
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string PreparationStepId { get; set; }

        public virtual PreparationStep PreparationStep { get; set; }
    }
}
