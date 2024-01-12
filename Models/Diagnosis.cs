using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            PatientHistory = new HashSet<PatientHistory>();
        }

        public int DiagnosisId { get; set; }
        public string Symptoms { get; set; }
        public string DiagnosisDesc { get; set; }
        public string DocNotes { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
    }
}
