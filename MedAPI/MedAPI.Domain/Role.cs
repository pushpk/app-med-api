namespace MedAPI.Domain
{
    public class Role
    {
        public long Id { get; set; }
        public byte[] Deletable { get; set; }
        public byte[] Deleted { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
