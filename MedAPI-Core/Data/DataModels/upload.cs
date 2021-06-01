using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class upload
    {
        public long id { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public bool deleted { get; set; }
        public string path { get; set; }

        public virtual noteexam_upload noteexam_upload { get; set; }
    }
}
