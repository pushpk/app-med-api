using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.models
{
    public class CardiovascularNote
    {
        public bool isDeleted { get; set; }
        public Skin skin { get; set; }
        public Pulses pulses { get; set; }
        public RespiratorySystem respiratorySystem { get; set; }
        public CardiovascularSystem cardiovascularSystem { get; set; }
        public Murmurs murmurs { get; set; }
        public GastrointestinalSemiology gastrointestinalSemiology
        {
            get; set;
        }
    }
}