using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Diagno
    {
        public int RepId { get; set; }
        public int? AId { get; set; }
        public int? PId { get; set; }
        public string PDiag { get; set; }
        public string PMed { get; set; }
        public string LabTest { get; set; }
        public string DNotes { get; set; }
        public string DPres { get; set; }

        public virtual Appointment A { get; set; }
        public virtual Patient P { get; set; }
    }
}
