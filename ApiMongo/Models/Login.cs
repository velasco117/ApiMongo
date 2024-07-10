using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ApiMongo.Models
{
    public class Login
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [BsonElement("name")]
        public String? Name { get; set; }

        [BsonElement("email")]
        //[BsonRepresentation(BsonType.ObjectId)]
        public String Email { get; set; }

        [BsonElement("phone")]
        public String? Phone { get; set; }
    
        [BsonElement("password")]
        public String Password { get; set; }


    }
}
