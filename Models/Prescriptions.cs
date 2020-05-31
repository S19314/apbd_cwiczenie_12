using System;
using System.Collections.Generic;

namespace Cwieczenie_12.Models
{
    public partial class Prescriptions
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
    }
}
