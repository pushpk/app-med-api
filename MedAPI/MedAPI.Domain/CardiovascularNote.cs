namespace MedAPI.Domain
{
    public class CardiovascularNote
    {
        public string AuscultationSite { get; set; }
        public string CapillaryRefillLLM { get; set; }
        public string CapillaryRefillLRM { get; set; }
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
        public string PulsesLLM { get; set; }
        public string PulsesLRM { get; set; }
        public string RadialPulsesL { get; set; }
        public string RadialPulsesR { get; set; }
        public bool SystolicPhase { get; set; }
        public bool ThirdNoise { get; set; }
        public bool TrophicChanges { get; set; }
        public string VesicularWhisperL { get; set; }
        public string VesicularWhisperR { get; set; }
        public long Id { get; set; }
    }
}
