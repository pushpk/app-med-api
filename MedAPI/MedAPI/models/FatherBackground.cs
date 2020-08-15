using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.models
{
    public class FatherBackground
    {
        public long fatherBackgroundId { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public bool isDeleted { get; set; }
    }
}