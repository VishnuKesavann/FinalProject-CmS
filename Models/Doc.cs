using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Doc
    {
        public Doc()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int DId { get; set; }
        public int? UId { get; set; }
        public string DName { get; set; }
        public string DSpec { get; set; }
        public int? ConFee { get; set; }

        public virtual Ulogin U { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
