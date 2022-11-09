using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace operait.Documents
{
    public class EscalationPolicy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<EscalationRule> EscalationRules { get; set; }

        public bool Repeat { get; set; }

        public int RepeatAfter { get; set; }
        public int RepeatTimes { get; set; }

        public bool RevertIfNotClosed { get; set; }
        public bool CloseIfRepeatsCompleted { get; set; }

    }
}
