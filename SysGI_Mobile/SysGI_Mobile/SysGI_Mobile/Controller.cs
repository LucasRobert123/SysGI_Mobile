using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using SysGI_Mobile.Models;
namespace SysGI_Mobile
{
    public class Controller
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

        
        public static bool keep_login, alow_notification = true;
        public static string user_logged_save, path_anexos;
        private static string path, path_data, path_infos, id_user_logged;
        private static DateTime last_recheck;

        public static int tot_up = 0, tot_dow = 0, tot_up_ok = 0, tot_dow_ok = 0;
        public static List<string> paths_anexos_offline,
            uploading = new List<string>(),
            downloading = new List<string>(),
            Credenciais = new List<string>() { "INDEFINIDO", "PROFESSOR", "ADVOGADO", "POLICIAL", "DELEGADO", "PROMOTOR", "JUIZ" };
    }

    public interface Interface<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(string id);
        IEnumerable<T> GetAll();
    }
}
