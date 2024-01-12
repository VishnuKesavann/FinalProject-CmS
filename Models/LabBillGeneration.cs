using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class LabBillGeneration
    {
        public int LabbillId { get; set; }
        public DateTime? LabbillDate { get; set; }
        public int? TotalAmount { get; set; }
        public int? PatientId { get; set; }
        public int? TestId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Laboratory Test { get; set; }
    }
}
