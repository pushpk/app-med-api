namespace MedAPI.Domain
{
    public class CardiovascularNote
    {
        public string AuscultationSite { get; set; }
        public string CapillaryRefillLLM { get; set; }
        public string CapillaryRefillLRM { get; set; }
        public string CardiacPressureIntensity { get; set; }
        public string CardiacPressureRhythm { get; set; }
        public byte[] DiastolicPhase { get; set; }
        public byte[] EdemaAnkle { get; set; }
        public byte[] EdemaGeneralized { get; set; }
        public byte[] EdemaLowerMembers { get; set; }
        public byte[] FourthNoise { get; set; }
        public string GastrointestinalSemiology { get; set; }
        public byte[] Murmurs { get; set; }
        public byte[] NeckRadiation { get; set; }
        public string OtherSymptoms { get; set; }
        public string PedalPulsesL { get; set; }
        public string PedalPulsesR { get; set; }
        public string PulsesLLM { get; set; }
        public string PulsesLRM { get; set; }
        public string RadialPulsesL { get; set; }
        public string RadialPulsesR { get; set; }
        public byte[] SystolicPhase { get; set; }
        public byte[] ThirdNoise { get; set; }
        public byte[] TrophicChanges { get; set; }
        public string VesicularWhisperL { get; set; }
        public string VesicularWhisperR { get; set; }
        public long Id { get; set; }
    }
}
