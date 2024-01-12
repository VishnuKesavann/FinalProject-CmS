using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            Billgen = new HashSet<Billgen>();
            Diagno = new HashSet<Diagno>();
        }

        public int PId { get; set; }
        public int? RId { get; set; }
        public string PName { get; set; }
        public int? PAge { get; set; }
        public string PGender { get; set; }
        public DateTime? PDov { get; set; }
        public string PDiag { get; set; }
        public string PPres { get; set; }
        public int? PPhno { get; set; }
        public string PAddress { get; set; }

        public virtual Recep R { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Billgen> Billgen { get; set; }
        public virtual ICollection<Diagno> Diagno { get; set; }
    }
}
