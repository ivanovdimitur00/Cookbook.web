using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataModels.Enums;
using Data.DataModels.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Data.DataModels.Entities.Identity
{
    public class ApplicationUser : IdentityUser, IAuditInfo
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 7);
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
            Claims = new HashSet<IdentityUserClaim<string>>();
            Logins = new HashSet<IdentityUserLogin<string>>();
            Recipes = new HashSet<Recipe>();
            Comments = new HashSet<Comment>();
            Favourites = new HashSet<Favourites>();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public PromotionStatus PromotionStatus { get; set; } = PromotionStatus.Neutral;

        public string PromotionLevel { get; set; }

        public string Nickname { get; set; }

        public bool UseRealName { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Favourites> Favourites { get; set; }
    }
}
