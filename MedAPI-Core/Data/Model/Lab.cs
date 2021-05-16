using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Lab
    {
        public Lab()
        {
            LabUploadResults = new HashSet<LabUploadResult>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string ParentCompany { get; set; }
        public string LabName { get; set; }
        public long Ruc { get; set; }
        public bool IsFreezed { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDenied { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<LabUploadResult> LabUploadResults { get; set; }
    }
}
