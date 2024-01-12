using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Ulogin
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Upwd { get; set; }
        public string Role { get; set; }

        public virtual Doc Doc { get; set; }
        public virtual Recep Recep { get; set; }
    }
}
