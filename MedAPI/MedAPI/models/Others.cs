using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.models
{
    public class Others
    {
        public long hdlCholesterol { get; set; }
        public long ldlCholesterol { get; set; }
        public long totalCholesterol { get; set; }
        public long glycemia { get; set; }
        public long glycatedHemoglobin { get; set; }
        public long urineAlbumin { get; set; }
        public long creatinineClearance { get; set; }

        public string specialities { get; set; }
    }
}