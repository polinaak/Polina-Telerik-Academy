using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDB.Data
{
    public static class MongoDBProvider
    {
        public static MongoDatabase db
        {
            get
            {
                var connectionstring = dbSetting.Default.MONGOLAB_URI; //"mongodb://bookstoredemo:bookstoredemo123@ds035428.mongolab.com:35428/bookstoredemo";// dbSetting.Default.MONGOLAB_URI;
                string dbName = MongoUrl.Create(connectionstring).DatabaseName;
                MongoServer dbServer = MongoServer.Create(connectionstring);
                MongoDatabase dbConnection = dbServer.GetDatabase(dbName, SafeMode.True);
                return dbConnection;
            }
        }
    }
}
