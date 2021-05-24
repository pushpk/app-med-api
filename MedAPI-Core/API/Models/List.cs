using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class List
    {
        public long id { get; set; }
        public string title { get; set; }
        public string code { get; set; }
        public Chapter chapter { get; set; }
        public string type { get; set; }
        public bool deleted { get; set; }
        public long chapterId { get; set; }

        public string concentration { get; set; }
        
        public string form { get; set; }
        public string fractions { get; set; }
        public string healthRegistration { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public string presentation { get; set; }
        public string indications { get; set; }
    }
}