using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.models
{
    public class Triage
    {
        public long triageId { get; set; }
        public BiologicalFunctions biologicalFunctions { get; set; }
        public VitalFunctions vitalFunctions { get; set; }
        public Others others { get; set; }
    }
}
