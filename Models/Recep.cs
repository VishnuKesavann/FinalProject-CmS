using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Recep
    {
        public Recep()
        {
            Patient = new HashSet<Patient>();
        }

        public int RId { get; set; }
        public int? UId { get; set; }
        public string RName { get; set; }

        public virtual Ulogin U { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
    }
}
