using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDb.Models
{
    public class Movie
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        public DateTime PublishDate { get; set; }

    }
}
