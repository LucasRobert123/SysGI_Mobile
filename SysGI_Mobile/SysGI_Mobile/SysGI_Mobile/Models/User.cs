using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysGI_Mobile.Models
{
    public class User
    {
        private string id, nome, email, telefone, passpassword;
        private int credencial;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public int Credencial { get => credencial; set => credencial = value; }
        public string Passpassword { get => passpassword; set => passpassword = value; }
    }
}
