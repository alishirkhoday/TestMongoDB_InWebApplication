using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMongoDB_InWebApplication.DataAccess.UseMongoDB
{
    public class MongodbContext
    {
        public IMongoDatabase MongodbContext()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("TestStore");
            return db;
        }
    }
}
