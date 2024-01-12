using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class PatientHistory
    {
        public int PatienthisId { get; set; }
        public int? DiagnosisId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? LabPrescId { get; set; }
        public int? LabreportId { get; set; }

        public virtual Diagnosis Diagnosis { get; set; }
        public virtual LabPresc LabPresc { get; set; }
        public virtual LabReportGeneration Labreport { get; set; }
        public virtual MedicinePresc Prescription { get; set; }
    }
}
