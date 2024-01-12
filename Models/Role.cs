using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Role
    {
        public Role()
        {
            Staff = new HashSet<Staff>();
            UserLogin = new HashSet<UserLogin>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<UserLogin> UserLogin { get; set; }
    }
}
