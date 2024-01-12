using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class LabPresc
    {
        public LabPresc()
        {
            PatientHistory = new HashSet<PatientHistory>();
        }

        public int LabPrescId { get; set; }
        public string LabtestName { get; set; }
        public string LabNote { get; set; }
        public string LabtestStatus { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
    }
}
