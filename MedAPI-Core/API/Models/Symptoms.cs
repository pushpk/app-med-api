using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Symptoms
    {
        public List[] list { get; set; }
        public string description { get; set; }
        public long duration { get; set; }
        public string durationUnit { get; set; }
        public string background { get; set; }
    }
}