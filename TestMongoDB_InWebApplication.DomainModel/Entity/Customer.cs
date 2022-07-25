using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMongoDB_InWebApplication.DomainModel.Entity
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string MobileNumber { get; set; }
        //public List<MobileNumber> MobileNumber { get; set; }
        //public MobileNumber MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
