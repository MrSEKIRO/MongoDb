using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Models;

public enum Gender
{
	Male,
	Female,
	Other,
}
[BsonIgnoreExtraElements]
public class Student
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string Id { get; set; }=string.Empty;

	[BsonElement("name")]
	public string Name { get; set; }=string.Empty;

	[BsonElement("isgraduted")]
	public bool IsGraduted { get; set; }
	[BsonElement("courses")]
	public string[]? Courses { get; set; }
	[BsonElement("gender")]
	public Gender Gender { get; set; }
	[BsonElement("age")]
	public int? Age { get; set; }
}
