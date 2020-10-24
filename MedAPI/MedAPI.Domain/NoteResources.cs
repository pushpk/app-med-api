using System.Collections.Generic;

namespace MedAPI.Domain
{
    public class NoteResources
    {
        public NoteResources()
        {
            hungers =new List<ObjectNode>();
            specialities = new List<ObjectNode>();
            thirsts = new List<ObjectNode>();
            sleeps = new List<ObjectNode>();
            urines = new List<ObjectNode>();
            weightEvolutions = new List<ObjectNode>();
            depositions = new List<ObjectNode>();
            cardiovascularSymptom = new List<ObjectNode>();
            medicines = new List<ObjectNode>();
            backgrounds = new List<ObjectNode>();
            physicalActivities = new List<ObjectNode>();
            sexes = new List<ObjectNode>();
        }

        public List<ObjectNode> specialities { get; set; }

        public List<ObjectNode> hungers { get; set; }
        public List<ObjectNode> thirsts { get; set; }
        public List<ObjectNode> sleeps { get; set; }
        public List<ObjectNode> urines { get; set; }
        public List<ObjectNode> weightEvolutions { get; set; }
        public List<ObjectNode> depositions { get; set; }
        public List<ObjectNode> cardiovascularSymptom { get; set; }
        public List<ObjectNode> medicines { get; set; }
        public List<ObjectNode> backgrounds { get; set; }
        public List<ObjectNode> physicalActivities { get; set; }
        public List<ObjectNode> sexes { get; set; }
    }
}
