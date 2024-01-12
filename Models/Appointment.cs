using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Billgen = new HashSet<Billgen>();
            Diagno = new HashSet<Diagno>();
        }

        public int AId { get; set; }
        public int? PId { get; set; }
        public int? DId { get; set; }
        public DateTime? ADate { get; set; }
        public string PReason { get; set; }
        public string AStatus { get; set; }
        public int? PPhno { get; set; }

        public virtual Doc D { get; set; }
        public virtual Patient P { get; set; }
        public virtual ICollection<Billgen> Billgen { get; set; }
        public virtual ICollection<Diagno> Diagno { get; set; }
    }
}
