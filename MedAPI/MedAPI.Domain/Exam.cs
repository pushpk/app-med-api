namespace MedAPI.Domain
{
    public class Exam
    {
        public long id { get; set; }
        public byte[] deleted { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}
