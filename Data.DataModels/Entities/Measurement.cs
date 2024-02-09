using Data.DataModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModels.Entities
{
    public class Measurement : BaseEntity
    {
        public Measurement()
        {
            RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        [Required]
        [Range(0.05, 100000)]
        public int Quantity { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Unit { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
