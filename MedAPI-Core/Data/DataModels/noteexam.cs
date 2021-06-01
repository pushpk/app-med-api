using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class noteexam
    {
        public noteexam()
        {
            noteexam_uploads = new HashSet<noteexam_upload>();
        }

        public long id { get; set; }
        public bool deleted { get; set; }
        public string observation { get; set; }
        public string specification { get; set; }
        public string status { get; set; }
        public long exam_id { get; set; }
        public long note_id { get; set; }

        public virtual exam exam { get; set; }
        public virtual note note { get; set; }
        public virtual ICollection<noteexam_upload> noteexam_uploads { get; set; }
    }
}
