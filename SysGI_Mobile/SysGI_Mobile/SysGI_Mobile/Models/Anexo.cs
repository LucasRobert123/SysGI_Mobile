using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysGI_Mobile.Models
{
    public class Anexo
    {
        private string id, infração_id;
        private string filename;
        private byte[] pdfContent;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get => id; set => id = value; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Infração_id { get => infração_id; set => infração_id = value; }
        public byte[] PdfContent { get => pdfContent; set => pdfContent = value; }
        public string Filename { get => filename; set => filename = value; }
    }
}
