namespace MedAPI.Domain
{
    public class Role
    {
        public long id { get; set; }
        public byte[] deletable { get; set; }
        public byte[] deleted { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }
}
