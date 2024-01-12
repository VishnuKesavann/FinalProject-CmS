using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            MedicinePresc = new HashSet<MedicinePresc>();
            PrescriptionBill = new HashSet<PrescriptionBill>();
        }

        public int MedicineId { get; set; }
        public int MedicineCode { get; set; }
        public string MedicineName { get; set; }
        public string GenericName { get; set; }
        public string CompanyName { get; set; }
        public int? MedicineStock { get; set; }
        public decimal? MedicineUnitPrice { get; set; }

        public virtual ICollection<MedicinePresc> MedicinePresc { get; set; }
        public virtual ICollection<PrescriptionBill> PrescriptionBill { get; set; }
    }
}
