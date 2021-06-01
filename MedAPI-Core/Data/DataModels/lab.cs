using System;
using System.Collections.Generic;

#nullable disable

namespace Data.DataModels
{
    public partial class lab
    {
        public lab()
        {
            lab_upload_results = new HashSet<lab_upload_result>();
        }

        public long id { get; set; }
        public long user_id { get; set; }
        public string parentCompany { get; set; }
        public string labName { get; set; }
        public long ruc { get; set; }
        public bool IsFreezed { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDenied { get; set; }

        public virtual user user { get; set; }
        public virtual ICollection<lab_upload_result> lab_upload_results { get; set; }
    }
}
