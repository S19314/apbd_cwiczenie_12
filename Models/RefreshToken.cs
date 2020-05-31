using System;
using System.Collections.Generic;

namespace Cwieczenie_12.Models
{
    public partial class RefreshToken
    {
        public string Id { get; set; }
        public string HashingPassword { get; set; }
        public string Salt { get; set; }
    }
}
