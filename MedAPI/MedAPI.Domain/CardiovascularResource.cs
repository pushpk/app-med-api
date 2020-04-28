using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class CardiovascularResource
    {
        public CardiovascularResource()
        {
            pulsesLLMs = new List<ObjectNode>();
            pulsesLRMs = new List<ObjectNode>();
            auscultationSites = new List<ObjectNode>();
            capillaryRefillLRMs = new List<ObjectNode>();
            capillaryRefillLLMs = new List<ObjectNode>();
            cardiacPressureRhythms = new List<ObjectNode>();
            cardiacPressureIntensities = new List<ObjectNode>();
            gastrointestinalSemiologies = new List<ObjectNode>();
            pedalPulsesLs = new List<ObjectNode>();
            pedalPulsesRs = new List<ObjectNode>();
            radialPulsesRs = new List<ObjectNode>();
            radialPulsesLs = new List<ObjectNode>();
            vesicularWhisperLs = new List<ObjectNode>();
            vesicularWhisperRs = new List<ObjectNode>();
        }

        public List<ObjectNode> pulsesLLMs { get; set; }
        public List<ObjectNode> pulsesLRMs { get; set; }
        public List<ObjectNode> auscultationSites { get; set; }
        public List<ObjectNode> capillaryRefillLRMs { get; set; }
        public List<ObjectNode> capillaryRefillLLMs { get; set; }
        public List<ObjectNode> cardiacPressureRhythms { get; set; }
        public List<ObjectNode> cardiacPressureIntensities { get; set; }
        public List<ObjectNode> gastrointestinalSemiologies { get; set; }
        public List<ObjectNode> pedalPulsesLs { get; set; }
        public List<ObjectNode> pedalPulsesRs { get; set; }
        public List<ObjectNode> radialPulsesRs { get; set; }
        public List<ObjectNode> radialPulsesLs { get; set; }
        public List<ObjectNode> vesicularWhisperLs { get; set; }
        public List<ObjectNode> vesicularWhisperRs { get; set; }
    }
}
