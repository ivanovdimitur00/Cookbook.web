using Data.DataModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModels.Entities
{
    public class PreparationStep : BaseEntity
    {
        public PreparationStep()
        {
            PreparationStepsList = new HashSet<PreparationStepsList>();
        }

        [Required]
        [Range(1, 24)]
        public int Number { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public virtual ICollection<PreparationStepsList> PreparationStepsList { get; set; }
    }
}
