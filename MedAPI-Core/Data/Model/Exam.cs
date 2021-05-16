using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Exam
    {
        public Exam()
        {
            Noteexams = new HashSet<Noteexam>();
        }

        public long Id { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Noteexam> Noteexams { get; set; }
    }
}
