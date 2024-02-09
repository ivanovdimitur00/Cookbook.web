using System.ComponentModel.DataAnnotations;
using Data.DataModels.Abstraction;
using System.Collections.Generic;

namespace Data.DataModels.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Recipes = new HashSet<Recipe>();
        }

        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
