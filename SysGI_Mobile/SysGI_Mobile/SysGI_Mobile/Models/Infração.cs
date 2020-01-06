using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysGI_Mobile.Models
{
    public class Infração
    {
        private string descrição;
        private DateTime data_ocorrência, data_registro;

        private string id;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get => id; set => id = value; }
        public string Descrição { get => descrição; set => descrição = value; }
        public DateTime Data_ocorrência { get => data_ocorrência; set => data_ocorrência = value; }
        public DateTime Data_registro { get => data_registro; set => data_registro = value; }
    }
}
