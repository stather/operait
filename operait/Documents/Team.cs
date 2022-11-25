using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace operait.Documents
{
    public class TeamMember
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public List<TeamMember> Members { get; set; } = new List<TeamMember>();

        public List<EscalationPolicy> EscalationPolicies { get; set; } = new List<EscalationPolicy>();

        public List<Schedule> Schedules { get; set; } = new List<Schedule>();

        public RoutingRule DefaultRoutingRule { get; set; }

        public List<RoutingRule> RoutingRules { get; set; }

    }
}
