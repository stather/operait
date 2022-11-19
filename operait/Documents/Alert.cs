using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace operait.Documents
{
    public enum ResponderType
    {
        Person,
        Team
    }
    public class Responder
    {
        public ResponderType Type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public enum AlertPriority
    {
        P1_Critical = 1,
        P2_High = 2,
        P3_Moderate = 3,
        P4_Low = 4,
        P5_Informational = 5
    }

    public class Note
    {
        public DateTime CreatedAt { get; set; }
        public string Who { get; set; }
        public string Data { get; set; }
    }


    public class ExtraProperty
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public enum ActivityType
    {
        System,
        AlertRecipient,
        Comment,
        AlertAction,
        Attachment
    }
    public class Activity
    {
        public ActivityType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Who { get; set; }
        public string Description { get; set; }
    }

    public enum ResponderStateValues
    {
        Notified,
        Seen,
        Action
    }
    public class ResponderState
    {
        public DateTime Timestamp { get; set; }
        public string Who { get; set; }
        public ResponderStateValues State { get; set; }

    }
    public enum AlertStatus
    {
        Open,
        Acked,
        Closed
    }
    public class Alert
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Alias { get; set; }

        public int TinyId { get; set; }
        public string ApiIntegrationId { get; set; }
        public int DeduplicationCounter { get; set; }

        public string AlertMessage { get; set; }

        public AlertPriority Priority { get; set; }

        public List<Responder> Responders { get; set; } = new List<Responder>();

        public string OwnerTeam { get; set; }

        public List<string> Tags { get; set; } = new List<string>();

        public AlertStatus Status { get; set; }

        public string Source { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }

        public string Description { get; set; }

        public List<ExtraProperty> ExtraProperties { get; set; } = new List<ExtraProperty>();

        public List<Note> Notes { get; set; }

        public List<string> Attachments { get; set; }

        public List<Activity> Activities { get; set; } = new List<Activity>();

        public List<ResponderState> ResponderStates { get; set; } = new List<ResponderState>();
    }
}
