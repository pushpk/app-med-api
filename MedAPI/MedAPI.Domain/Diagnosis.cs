using System.Collections.Generic;

namespace MedAPI.Domain
{
    public class Diagnosis
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public byte[] Deleted { get; set; }
        public string Title { get; set; }
        public long ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}
