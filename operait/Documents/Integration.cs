using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace operait.Documents
{
    public enum IntegrationType
    {
        API,
        Outgoing,
        BiDirectional,
        Chat,
        Email
    }

    public class Integration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string TeamId { get; set; }
        public string  TeamName { get; set; }

        public IntegrationType IntegrationType { get; set; }
        public bool Enabled { get; set; }
        public bool SuppressNotifications { get; set; }

        public List<string> Tags { get; set; }
        public List<ExtraProperty> MyProperty { get; set; }

        public AlertPriority Priority { get; set; }

        public ApiAttributes ApiAttributes { get; set; }
    }

    public class ApiAttributes
    {
        public string ApiKey { get; set; }
        public bool ReadAccess { get; set; }
        public bool CreateAndUpdateAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public bool RestrictConfigurationAccess { get; set; }


    }
}
