using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CollegeAdministration.Infrastructure
{
    public class MongoDBContext
    {
        MongoClient _mc;
        MongoServer _ms;
        public MongoDatabase _db;
        public MongoDBContext()
        {
            var dbName = ConfigurationManager.AppSettings["MongoDatabaseName"];
            var userName = ConfigurationManager.AppSettings["MongoUsername"];
            var pwd = ConfigurationManager.AppSettings["MongoPassword"];
            var portNbr = int.Parse(ConfigurationManager.AppSettings["MongoPort"]);
            var host = ConfigurationManager.AppSettings["MongoHost"];

            var credential = MongoCredential.CreateCredential(dbName, userName, pwd);
            var mClient = new MongoClientSettings
            {
                Credential = credential,
                Server = new MongoServerAddress(host, portNbr)
            };
            _mc = new MongoClient(mClient);
            _ms = _mc.GetServer();
            _db = _ms.GetDatabase(dbName);
        }

    }
}