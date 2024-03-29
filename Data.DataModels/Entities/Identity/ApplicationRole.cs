﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataModels.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Data.DataModels.Entities.Identity
{
    public class ApplicationRole : IdentityRole, IAuditInfo
    {
        public ApplicationRole(string name)
            : base(name)
        {
            Id = Guid.NewGuid().ToString().Substring(0, 7);
        }

        public ApplicationRole()
            : this(null)
        {
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
