using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.DTOs
{
    public class Home
    {
        public int rooms { get; set; }
        public int population { get; set; }
        public string type { get; set; }
        public string ownership { get; set; }
        public string material { get; set; }
        public bool electricity { get; set; }
        public bool water { get; set; }
        public bool sewage { get; set; }
    }
}