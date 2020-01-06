using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using SysGI_Mobile.Models;
using System.Threading.Tasks;

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
        
        private struct Responsavel
        {
            public string email;
            public int categoria;
        }

        public static List<string> Credenciais = new List<string>() { "INDEFINIDO", "PROFESSOR", "ADVOGADO", "POLICIAL", "DELEGADO", "PROMOTOR", "JUIZ" };
        public List<string> anexo_formats = new List<string>() { ".pdf", ".jpeg", ".jpg", ".png" };
        private static List<Responsavel> responsaveis;

        public static void Load_Responsaveis()
        {
            responsaveis = new List<Responsavel>();
            responsaveis.Add(new Responsavel() { categoria = 1, email = "adrieldeveloper@hotmail.com" });
            responsaveis.Add(new Responsavel() { categoria = 2, email = "lucasrobert994@gmail.com" });
            responsaveis.Add(new Responsavel() { categoria = 3, email = "adrieldeveloper@hotmail.com" });
            responsaveis.Add(new Responsavel() { categoria = 4, email = "lucasrobert994@gmail.com" });
            responsaveis.Add(new Responsavel() { categoria = 5, email = "adrieldeveloper@hotmail.com" });
        }

        public static int[] podem_cadastrar = new int[4]
        {
            //(int)Credencial.Professor,
            (int)Credencial.Advogado,
            (int)Credencial.Policial,
            (int)Credencial.Delegado,
            //(int)Credencial.Promotor,
            (int)Credencial.Juiz,
        };
        public static int[] podem_consultar = new int[6]
        {
            (int)Credencial.Professor,
            (int)Credencial.Advogado,
            (int)Credencial.Policial,
            (int)Credencial.Delegado,
            (int)Credencial.Promotor,
            (int)Credencial.Juiz,
        };
        public static int[] podem_ver_perfil = new int[5]
        {
            //(int)Credencial.Professor,
            (int)Credencial.Advogado,
            (int)Credencial.Policial,
            (int)Credencial.Delegado,
            (int)Credencial.Promotor,
            (int)Credencial.Juiz,
        };
        public static int[] podem_salvar_edição = new int[4]
        {
            //(int)Credencial.Professor,
            (int)Credencial.Advogado,
            (int)Credencial.Policial,
            (int)Credencial.Delegado,
            //(int)Credencial.Promotor,
            (int)Credencial.Juiz,
        };
        public static int[] podem_ver_anexos = new int[5]
        {
            //(int)Credencial.Professor,
            (int)Credencial.Advogado,
            (int)Credencial.Policial,
            (int)Credencial.Delegado,
            (int)Credencial.Promotor,
            (int)Credencial.Juiz,
        };
        public static int[] podem_editar_anexos = new int[5]
        {
            //(int)Credencial.Professor,
            (int)Credencial.Advogado,
            (int)Credencial.Policial,
            (int)Credencial.Delegado,
            (int)Credencial.Promotor,
            (int)Credencial.Juiz,
        };

        public static void Show_Permission_Alert()
        {
            //Forms_Controller.pode_desconectar = false;
            //MessageBox.Show("Infelizmente você não tem\npermissão para acessar\neste recurso no momento!", "Atenção:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //Forms_Controller.pode_desconectar = true;
        }
    }

    public interface Interface<T>
    {
        Task<bool> Add(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(T item);
        T GetById(string id);
        IEnumerable<T> GetAll();
    }
}
