using System.ComponentModel.DataAnnotations;
using Data.DataModels.Abstraction;
using System.Collections.Generic;

namespace Data.DataModels.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            //FilmProductions = new HashSet<FilmProduction>(); - for recipes when implementing the DB tables
        }

        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        //public virtual ICollection<FilmProduction> FilmProductions { get; set; } -- for recipes when implementing the DB tables
    }
}
