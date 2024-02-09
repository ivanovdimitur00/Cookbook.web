using Data.DataModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.DataModels.Entities
{
    public class Tag : BaseEntity
    {
        public Tag()
        {
            RecipeTags = new HashSet<RecipeTag>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public virtual ICollection<RecipeTag> RecipeTags { get; set; }
    }
}
