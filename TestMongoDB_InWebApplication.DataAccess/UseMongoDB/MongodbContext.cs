using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMongoDB_InWebApplication.DataAccess.UseMongoDB
{
    public static class MongodbContext
    {
        public static IMongoDatabase Context()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("TestStore1");
            return db;
        }
    }
}
