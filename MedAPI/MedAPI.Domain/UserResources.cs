using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class UserResources
    {
        public UserResources()
        {
            maritalStatuses = new List<ObjectNode>();
            bloodTypes = new List<ObjectNode>();
            documentTypes = new List<ObjectNode>();
            educationalAttainments = new List<ObjectNode>();
            homeMaterials = new List<ObjectNode>();
            homeOwnerships = new List<ObjectNode>();
            homeTypes = new List<ObjectNode>();
            physicalActivities = new List<ObjectNode>();
            sexes = new List<ObjectNode>();
            departments = new List<ObjectNode>();
            countries = new List<ObjectNode>();
            medicines = new List<ObjectNode>();
            backgrounds = new List<ObjectNode>();
            allergies = new List<ObjectNode>();
            alcoholConsumptions = new List<ObjectNode>();
            fvConsumptions = new List<ObjectNode>();
            races = new List<ObjectNode>();
            provinces = new List<ObjectNode>();
            districts = new List<ObjectNode>();
              specialities = new List<string>();
        }

        public List<ObjectNode> maritalStatuses { get; set; }
        public List<ObjectNode> bloodTypes { get; set; }
        public List<ObjectNode> documentTypes { get; set; }
        public List<ObjectNode> educationalAttainments { get; set; }
        public List<ObjectNode> homeMaterials { get; set; }
        public List<ObjectNode> homeOwnerships { get; set; }
        public List<ObjectNode> homeTypes { get; set; }
        public List<ObjectNode> physicalActivities { get; set; }
        public List<ObjectNode> sexes { get; set; }
        public List<ObjectNode> departments { get; set; }
        public List<ObjectNode> countries { get; set; }
        public List<ObjectNode> medicines { get; set; }
        public List<ObjectNode> backgrounds { get; set; }
        public List<ObjectNode> allergies { get; set; }
        public List<ObjectNode> alcoholConsumptions { get; set; }
        public List<ObjectNode> fvConsumptions { get; set; }
        public List<ObjectNode> races { get; set; }
        public List<ObjectNode> provinces { get; set; }
        public List<ObjectNode> districts { get; set; }

        public List<string> specialities { get; set; }
    }
}
