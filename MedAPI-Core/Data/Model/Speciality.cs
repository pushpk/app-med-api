using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Speciality
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
    }
}
