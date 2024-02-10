using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModels.Entities
{
    public class RecipeIngredients
    {
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string MeasurementId { get; set; }

        public virtual Measurement Measurement { get; set; }

        public string IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
