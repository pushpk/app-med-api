using System;

namespace Repository.DTOs
{
    public class CardiovascularNote
    {
        public string auscultationSite { get; set; }
        public string capillaryRefillLLM { get; set; }
        public string capillaryRefillLRM { get; set; }
        public string cardiacPressureIntensity { get; set; }
        public string cardiacPressureRhythm { get; set; }
        public bool diastolicPhase { get; set; }
        public bool edemaAnkle { get; set; }
        public bool edemaGeneralized { get; set; }
        public bool edemaLowerMembers { get; set; }
        public bool fourthNoise { get; set; }
        public string gastrointestinalSemiology { get; set; }
        public bool murmurs { get; set; }
        public bool neckRadiation { get; set; }
        public string otherSymptoms { get; set; }
        public string pedalPulsesL { get; set; }
        public string pedalPulsesR { get; set; }
        public string pulsesLLM { get; set; }
        public string pulsesLRM { get; set; }
        public string radialPulsesL { get; set; }
        public string radialPulsesR { get; set; }
        public bool systolicPhase { get; set; }
        public bool thirdNoise { get; set; }
        public bool trophicChanges { get; set; }
        public string vesicularWhisperL { get; set; }
        public string vesicularWhisperR { get; set; }
        public long? noteId { get; set; }
        public long id { get; set; }
    }
}
