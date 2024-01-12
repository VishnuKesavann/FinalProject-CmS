using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Billgen
    {
        public int BId { get; set; }
        public int? AId { get; set; }
        public int? PId { get; set; }
        public string BStatus { get; set; }

        public virtual Appointment A { get; set; }
        public virtual Patient P { get; set; }
    }
}
