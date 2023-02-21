using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace operait.Documents
{
    public class Sequence
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public int Value { get; set; }
    }
}
