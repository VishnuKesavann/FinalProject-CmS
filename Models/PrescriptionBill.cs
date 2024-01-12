using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class PrescriptionBill
    {
        public int BillId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? MedicineId { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int? PatientId { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual MedicinePresc Prescription { get; set; }
    }
}
