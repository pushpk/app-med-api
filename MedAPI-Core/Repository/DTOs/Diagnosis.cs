using System.Collections.Generic;

namespace Repository.DTOs
{
    public class Diagnosis
    {
        public long id { get; set; }
        public string code { get; set; }
        public bool deleted { get; set; }
        public string title { get; set; }
        public long chapterId { get; set; }
        public Chapter chapter { get; set; }
    }
}
