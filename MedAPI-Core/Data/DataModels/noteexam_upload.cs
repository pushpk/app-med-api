using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class noteexam_upload
    {
        public long id { get; set; }
        public long? noteExam_id { get; set; }
        public long? uploads_id { get; set; }

        public virtual noteexam noteExam { get; set; }
        public virtual upload uploads { get; set; }
    }
}
