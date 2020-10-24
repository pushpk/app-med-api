using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
    public class SymptomsWithCustom
    {
        public string documentNumber { get; set; }
        
        public Symptoms[] symptoms { get; set; }

        public string Custom_Symptom { get; set; }

        

    }
}
