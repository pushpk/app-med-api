using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Model
{
    public partial class Cardiovascularnote
    {
        public Cardiovascularnote()
        {
            CardiovascularnoteCardiovascularsymptoms = new HashSet<CardiovascularnoteCardiovascularsymptom>();
        }

        public long Id { get; set; }
        public long? NoteId { get; set; }
        public string AuscultationSite { get; set; }
        public string CapillaryRefillLlm { get; set; }
        public string CapillaryRefillLrm { get; set; }
        public string CardiacPressureIntensity { get; set; }
        public string CardiacPressureRhythm { get; set; }
        public bool DiastolicPhase { get; set; }
        public bool EdemaAnkle { get; set; }
        public bool EdemaGeneralized { get; set; }
        public bool EdemaLowerMembers { get; set; }
        public bool FourthNoise { get; set; }
        public string GastrointestinalSemiology { get; set; }
        public bool Murmurs { get; set; }
        public bool NeckRadiation { get; set; }
        public string OtherSymptoms { get; set; }
        public string PedalPulsesL { get; set; }
        public string PedalPulsesR { get; set; }
        public string PulsesLlm { get; set; }
        public string PulsesLrm { get; set; }
        public string RadialPulsesL { get; set; }
        public string RadialPulsesR { get; set; }
        public bool SystolicPhase { get; set; }
        public bool ThirdNoise { get; set; }
        public bool TrophicChanges { get; set; }
        public string VesicularWhisperL { get; set; }
        public string VesicularWhisperR { get; set; }
        public bool IsDelete { get; set; }

        public virtual Note Note { get; set; }
        public virtual ICollection<CardiovascularnoteCardiovascularsymptom> CardiovascularnoteCardiovascularsymptoms { get; set; }
    }
}
