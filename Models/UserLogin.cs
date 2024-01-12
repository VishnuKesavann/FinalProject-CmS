﻿using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            Staff = new HashSet<Staff>();
        }

        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
