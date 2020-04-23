using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Chapter
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public byte[] Deleted { get; set; }
        public string Title { get; set; }
    }
}
