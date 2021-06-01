using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class lab_upload_result
    {
        public long id { get; set; }
        public long user_id { get; set; }
        public long? lab_id { get; set; }
        public long? medic_user_id { get; set; }
        public string fileName { get; set; }
        public string comments { get; set; }
        public byte[] fileContent { get; set; }
        public DateTime? dateUploaded { get; set; }

        public virtual lab lab { get; set; }
        public virtual medic medic_user { get; set; }
        public virtual user user { get; set; }
    }
}
