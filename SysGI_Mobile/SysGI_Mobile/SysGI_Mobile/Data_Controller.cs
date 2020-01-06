using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using SysGI_Mobile.Models;
namespace SysGI_Mobile
{
    public class Data_Controller
    {
        public enum Credencial : int
        {
            Indefinido = 0,
            Professor = 1,
            Advogado = 2,
            Policial = 3,
            Delegado = 4,
            Promotor = 5,
            Juiz = 6
        }
        public static List<User> users;
        public static List<Infrator> infratores;
        public static User user_logged;
        public static bool keep_login, alow_notification = true;
        public static string user_logged_save, path_anexos;
        private static string path, path_data, path_infos, id_user_logged;
        private static DateTime last_recheck;

        public const string str_Connection = "mongodb+srv://SGMI_User:SGMI2019@sgmicluster-boq9i.gcp.mongodb.net/test?retryWrites=true&w=majority";
        private static MongoClient client;
        public static IMongoDatabase database;
        private static IMongoCollection<Infrator> collection_infratores;
        public static IMongoCollection<User> collection_users;
        private static IMongoCollection<BsonDocument> collection_logged_users;
        private static IMongoCollection<Infrator_Favorito> collection_infratores_favoritados;
        public static IMongoCollection<Infrator> Collection_Infratores { get => collection_infratores; }

        public static int tot_up = 0, tot_dow = 0, tot_up_ok = 0, tot_dow_ok = 0;
        public static List<string> paths_anexos_offline,
            uploading = new List<string>(),
            downloading = new List<string>(),
            Credenciais = new List<string>() { "INDEFINIDO", "PROFESSOR", "ADVOGADO", "POLICIAL", "DELEGADO", "PROMOTOR", "JUIZ" };
           
        public static async void Add_User(User user)
        {
           await collection_users.InsertOneAsync(user);
            
        }
    }
}
