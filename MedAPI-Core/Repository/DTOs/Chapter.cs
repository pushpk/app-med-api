using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
   public class Chapter
    {
        public long id { get; set; }
        public string code { get; set; }
        public byte[] deleted { get; set; }
        public string title { get; set; }
    }
}
