using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace operait.Documents
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public List<string> Users { get; set; } = new List<string>();

        public List<EscalationPolicy> EscalationPolicies { get; set; } = new List<EscalationPolicy>();

        public List<Schedule> Schedules { get; set; } = new List<Schedule>();

        public RoutingRule DefaultRoutingRule { get; set; }

        public List<RoutingRule> RoutingRules { get; set; }

    }
}
