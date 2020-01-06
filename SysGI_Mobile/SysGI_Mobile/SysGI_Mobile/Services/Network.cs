using MongoDB.Bson;
using MongoDB.Driver;
using SysGI_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysGI_Mobile.Services
{
    public class Network
    {
        public const string str_Connection = "mongodb+srv://SGMI_User:SGMI2019@sgmicluster-boq9i.gcp.mongodb.net/test?retryWrites=true&w=majority";
        private static MongoClient client;
        public static IMongoDatabase database;
        private static IMongoCollection<Infrator> collection_infratores;
        public static IMongoCollection<User> collection_users;
        private static IMongoCollection<BsonDocument> collection_logged_users;
        private static IMongoCollection<Infrator_Favorito> collection_infratores_favoritados;
        public static IMongoCollection<Infrator> Collection_Infratores { get => collection_infratores; }

        public static bool Connect()
        {
            try
            {
                // conectar no mongo e as collection
                return true;
            }
            catch { return false; }
        }

    }
}
