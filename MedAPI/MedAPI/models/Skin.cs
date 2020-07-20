using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.models
{
    public class Skin
    {
        public string capillaryRefillLLM { get; set; }
        public string capillaryRefillLRM { get; set; }
        public bool trophicChanges { get; set; }
        public bool edemaAnkle { get; set; }
        public bool edemaLowerMember { get; set; }
        public bool edemaGeneralized { get; set; }
    }
}