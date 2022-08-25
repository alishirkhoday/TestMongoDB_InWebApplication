using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestMongoDB_InWebApplication.DomainModel.Entity
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public DateOnly BirthDate { get; set; }
        public int Age { get; set; }
        //public string MobileNumber { get; set; }
        //public MobileNumber MobileNumber { get; set; }
        public List<MobileNumber> MobileNumbers { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
