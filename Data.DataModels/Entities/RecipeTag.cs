using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModels.Entities
{
    public class RecipeTag
    {
        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}