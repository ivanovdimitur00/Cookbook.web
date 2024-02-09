using Data.DataModels.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModels.Entities
{
    public class Favourites
    {
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
