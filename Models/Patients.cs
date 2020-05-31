using System;
using System.Collections.Generic;

namespace Cwieczenie_12.Models
{
    public partial class Patients
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
