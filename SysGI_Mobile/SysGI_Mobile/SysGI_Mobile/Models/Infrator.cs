using System;
using System.Collections.Generic;
using System.Text;

namespace SysGI_Mobile.Models
{
    public class Infrator
    {
        private string id;
        private string nome, cpf, rg, mãe, logradouro, num_residência, bairro, cidade, uf;
        private char sexo;
        private DateTime data_nascimento, data_registro;
        private List<Infração> infrações;

        public Infrator()
        {
            Infrações = new List<Infração>();
        }

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Mãe { get => mãe; set => mãe = value; }
        public string Logradouro { get => logradouro; set => logradouro = value; }
        public string Num_residência { get => num_residência; set => num_residência = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Uf { get => uf; set => uf = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public DateTime Data_nascimento { get => data_nascimento; set => data_nascimento = value; }
        public DateTime Data_registro { get => data_registro; set => data_registro = value; }
        public List<Infração> Infrações { get => infrações; set => infrações = value; }
    }

    public class Infrator_Favorito
    {
        private string id, id_infrator;
        private List<string> users_watching;

        public Infrator_Favorito() { users_watching = new List<string>(); }

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get => id; set => id = value; }

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id_infrator { get => id_infrator; set => id_infrator = value; }
        public List<string> Users_watching { get => users_watching; set => users_watching = value; }
    }

}
