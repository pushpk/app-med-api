using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.models
{
    public class Patient
    {
        public long id { get; set; }
        public string race { get; set; }
        public string educationalAttainment { get; set; }
        public string occupation { get; set; }
        public string bloodType { get; set; }
        public string alcoholConsumption { get; set; }
        public string physicalActivity { get; set; }
        public string fvConsumption { get; set; }
        public Home home { get; set; }
        public Allergy[] allergies { get; set; }
        public string otherAllergies { get; set; }

        public Medicine[] medicines { get; set; }
        public string otherMedicines { get; set; }

        public PersonalBackground[] personalBackground { get; set; }
        public string otherPersonalBackground { get; set; }

        public FatherBackground[] fatherBackground { get; set; }
        public string otherFatherBackground { get; set; }

        public MotherBackground[] motherBackground { get; set; }
        public string otherMotherBackground { get; set; }
        public long? cigaretteNumber { get; set; }

        public string name { get; set; }
        public string lastnameFather { get; set; }
        public string lastnameMother { get; set; }
        public long country { get; set; }
        public string documentType { get; set; }
        public string documentNumber { get; set; }        
        public DateTime birthday { get; set; }
        public string sex { get; set; }
        public string maritalStatus { get; set; }
        public long? district { get; set; }
        public long? department { get; set; }
        public long? province { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public bool deletable { get; set; }
        public bool deleted { get; set; }

        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public bool isDonor { get; set; }
        public string passwordHash { get; set; }

        public long? fractureNumber { get; set; }
        public long? dormNumber { get; set; }
        public string highGlucose { get; set; }
    }
}