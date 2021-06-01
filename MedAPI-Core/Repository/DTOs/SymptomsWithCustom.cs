using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
    public class SymptomsWithCustom
    {
        public string documentNumber { get; set; }
        
        public Symptoms[] symptoms { get; set; }

        public string Custom_Symptom { get; set; }

        

    }
}
