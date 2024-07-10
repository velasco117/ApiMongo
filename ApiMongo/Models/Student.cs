using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ApiMongo.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [BsonElement("nameProduct")]
        public String NameProduct { get; set; }

        [BsonElement("numberProduct")]
        public String NumberProduct { get; set; }

    }
}
