using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMongoDB_InWebApplication.DomainModel.Entity
{
    public class MobileNumber
    {
        public string Value { get; set; }
    }
}
