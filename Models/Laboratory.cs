﻿using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Laboratory
    {
        public Laboratory()
        {
            LabBillGeneration = new HashSet<LabBillGeneration>();
            LabReportGeneration = new HashSet<LabReportGeneration>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public string LowRange { get; set; }
        public string HighRange { get; set; }
        public decimal? TestPrice { get; set; }

        public virtual ICollection<LabBillGeneration> LabBillGeneration { get; set; }
        public virtual ICollection<LabReportGeneration> LabReportGeneration { get; set; }
    }
}
