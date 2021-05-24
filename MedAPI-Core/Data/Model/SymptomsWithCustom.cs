using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class SymptomsWithCustom
    {
        public string documentNumber { get; set; }
        
        public Symptom[] symptoms { get; set; }

        public string Custom_Symptom { get; set; }

        

    }
}
