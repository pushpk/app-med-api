using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class LabUploadResult
    {
        public LabUploadResult()
        {
           
        }

        public long id { get; set; }

        public byte[] fileContent { get; set; }
        public string fileName { get; set; }
        public string comments { get; set; }

        public Nullable<System.DateTime> dateUploaded { get; set; }

        public long user_id { get; set; }

        public string patient_docNumber { get; set; }

        public Nullable<long> labId { get; set; }

        public Nullable<long> medicId { get; set; }



    }
}
