using System;
using System.Collections.Generic;

namespace Cwieczenie_12.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
