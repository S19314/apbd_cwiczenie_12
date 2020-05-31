using System;
using System.Collections.Generic;

namespace Cwieczenie_12.Models
{
    public partial class PrescriptionMedicament
    {
        public int IdPrescription { get; set; }
        public int IdMedicament { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }
        public int? PrescriptionIdPrescription { get; set; }

        public virtual Medicament IdMedicamentNavigation { get; set; }
        public virtual Prescription PrescriptionIdPrescriptionNavigation { get; set; }
    }
}
