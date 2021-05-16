using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class LabUploadResult
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long? LabId { get; set; }
        public long? MedicUserId { get; set; }
        public string FileName { get; set; }
        public string Comments { get; set; }
        public byte[] FileContent { get; set; }
        public DateTime? DateUploaded { get; set; }

        public virtual Lab Lab { get; set; }
        public virtual Medic MedicUser { get; set; }
        public virtual User User { get; set; }
    }
}
