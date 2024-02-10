using Data.DataModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModels.Entities
{
    public class Ingredient : BaseEntity
    {
        public Ingredient()
        {
            RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        public bool IsAllergen { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
