namespace MedAPI.Domain
{
    public class Exam
    {
        public long Id { get; set; }
        public byte[] Deleted { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
