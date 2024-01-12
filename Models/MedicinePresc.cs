using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class MedicinePresc
    {
        public MedicinePresc()
        {
            PatientHistory = new HashSet<PatientHistory>();
            PrescriptionBill = new HashSet<PrescriptionBill>();
        }

        public int PrescriptionId { get; set; }
        public string MedpresName { get; set; }
        public string Dosage { get; set; }
        public int? DosageDays { get; set; }
        public int? Quantity { get; set; }
        public int? AppointmentId { get; set; }
        public int? MedicineId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
        public virtual ICollection<PrescriptionBill> PrescriptionBill { get; set; }
    }
}
