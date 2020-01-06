using MongoDB.Bson;
using MongoDB.Driver;
using SysGI_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SysGI_Mobile.Services
{
    public class Network
    {
        private const string str_Connection = "mongodb+srv://SGMI_User:SGMI2019@sgmicluster-boq9i.gcp.mongodb.net/test?retryWrites=true&w=majority";
        private static MongoClient client;
        private static IMongoDatabase database;

        private static IMongoCollection<User> collection_users;
        private static IMongoCollection<Anexo> collection_anexos;
        private static IMongoCollection<Infrator> collection_infratores;
        private static IMongoCollection<BsonDocument> collection_logged_users;
        private static IMongoCollection<Infrator_Favorito> collection_infratores_favoritados;

        public static IMongoCollection<User> Collection_users { get; }
        public static IMongoCollection<Anexo> Collection_anexos { get; }
        public static IMongoCollection<Infrator> Collection_infratores { get; }
        public static IMongoCollection<BsonDocument> Collection_logged_users { get; }
        public static IMongoCollection<Infrator_Favorito> Collection_infratores_favoritados { get; }

        public static bool keep_login, keep_running = true, alow_notification = true;
        private static DateTime last_recheck;

        public static int tot_up = 0, tot_dow = 0, tot_up_ok = 0, tot_dow_ok = 0;

        public static List<string> uploading = new List<string>(), downloading = new List<string>();

        public struct Sys_Email
        {
            public const string email = "sysGI@hotmail.com", senha = "@d1minL0gin1";
        }

        public static bool Connect()
        {
            try
            {
                client = new MongoClient(str_Connection);
                database = client.GetDatabase("SGMI");
                collection_users = database.GetCollection<User>("users");
                collection_anexos = database.GetCollection<Anexo>("anexos");
                collection_infratores = database.GetCollection<Infrator>("infratores");
                collection_logged_users = database.GetCollection<BsonDocument>("logged_users");
                collection_infratores_favoritados = database.GetCollection<Infrator_Favorito>("infratores_favoritados");
                return true;
            }
            catch { return false; }
        }

        public static void Watch_Infrator_Insert()
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<Infrator>>()
                .Match(change =>
                    change.FullDocument.Nome != "" &&
                    change.OperationType == ChangeStreamOperationType.Insert);

            using (var cursor = collection_infratores.Watch(pipeline))
            {
                try
                {
                    while (cursor.MoveNext() && cursor.Current.Count() == 0 && keep_running) { }
                    var infrator_inserido = cursor.Current.First().FullDocument;

                    //if (alow_notification && isFavorite(infrator_inserido.Id))
                    //{
                    //    frm_Principal.instancia.Show_Notify("Infrator inserido!", "Nome: " + infrator_inserido.Nome, ToolTipIcon.Info);
                    //}
                    //infratores.Add(infrator_inserido);
                }
                catch { }

                //if (keep_running) { Start_Thread(new Thread(() => Start_Infrator_Insert_Watch())); }
                //Stop_Thread(Thread.CurrentThread);
            }
        }
        public static void Watch_Infrator_Update()
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<Infrator>>()
                .Match(change =>
                    change.FullDocument.Nome != "" && (
                    change.OperationType == ChangeStreamOperationType.Replace ||
                    change.OperationType == ChangeStreamOperationType.Update
                    ));

            using (var cursor = collection_infratores.Watch(pipeline))
            {
                try
                {
                    while (cursor.MoveNext() && cursor.Current.Count() == 0 && keep_running) { }

                    //Infrator infrator_atualizado = infratores.FirstOrDefault(i => i.Id.ToString().Contains(cursor.Current.First().DocumentKey["_id"].ToString()));
                    //if (alow_notification && isFavorite(infrator_atualizado.Id))
                    //{
                    //    frm_Principal.instancia.Show_Notify("Infrator atualizado!", "Nome: " + infrator_atualizado.Nome, ToolTipIcon.Info);
                    //}
                    //if (frmConsulta_Menor.instancia != null)
                    //{
                    //    frmConsulta_Menor.instancia.PictureBox1_Click(frmConsulta_Menor.instancia, new EventArgs());
                    //}
                }
                catch { }

                //if (keep_running) { Start_Thread(new Thread(() => Start_Infrator_Update_Watch())); }
                //Stop_Thread(Thread.CurrentThread);
            }
        }
        public static void Watch_Infrator_Delete()
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<Infrator>>()
                .Match(change =>
                    change.FullDocument.Nome != "" &&
                    change.OperationType == ChangeStreamOperationType.Delete);


            using (var cursor = collection_infratores.Watch(pipeline))
            {
                try
                {
                    while (cursor.MoveNext() && cursor.Current.Count() == 0 && keep_running) { }

                    //Infrator infrator_removido = infratores.FirstOrDefault(i => i.Id.ToString().Contains(cursor.Current.First().DocumentKey["_id"].ToString()));

                    //if (infrator_removido != null)
                    //{
                    //    if (isFavorite(infrator_removido.Id))
                    //    {
                    //        if (alow_notification) { frm_Principal.instancia.Show_Notify("Infrator removido!", "Nome: " + infrator_removido.Nome, ToolTipIcon.Info); }
                    //        Remove_Favorite(infrator_removido.Id, true);
                    //    }

                    //    infratores.Remove(infrator_removido);
                    //}
                }
                catch { }
                //if (keep_running) { Start_Thread(new Thread(() => Start_Infrator_Delete_Watch())); }
                //Stop_Thread(Thread.CurrentThread);
            }
        }
        public static void Watch_Anexo_Insert()
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<Anexo>>()
                .Match(change => change.OperationType == ChangeStreamOperationType.Insert);

            using (var cursor = collection_anexos.Watch(pipeline))
            {
                try
                {
                    while (cursor.MoveNext() && cursor.Current.Count() == 0 && keep_running) { }

                    //var anexo_inserido = cursor.Current.First().FullDocument;
                    //var infrator_relacionado = infratores.FirstOrDefault(i => i.Infrações.Select(infra => infra.Id).Contains(anexo_inserido.Infração_id));

                    //if (infrator_relacionado != null && alow_notification && isFavorite(infrator_relacionado.Id))
                    //{
                    //    frm_Principal.instancia.Show_Notify("Anexo adicionado!", "Infrator: " + infrator_relacionado.Nome, ToolTipIcon.Info);
                    //}
                    //if (frm_Detalhes.instancia != null)
                    //{
                    //    while (!Forms_Controller.pode_desconectar) ;
                    //    frm_Detalhes.instancia.Load_Anexos();
                    //}
                }
                catch { }

                //if (keep_running) { Start_Thread(new Thread(() => Start_Anexo_Insert_Watch())); }
                //Stop_Thread(Thread.CurrentThread);
            }
        }
        public static void Watch_Anexo_Delete()
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<Anexo>>()
                .Match(change => change.OperationType == ChangeStreamOperationType.Delete);

            using (var cursor = collection_anexos.Watch(pipeline))
            {
                try
                {
                    while (cursor.MoveNext() && cursor.Current.Count() == 0 && keep_running) { }

                    //if (alow_notification && Web_Tools.Conectado_A_Internet())
                    //{
                    //    Clear_Anexos();
                    //    frm_Principal.instancia.Show_Notify("Anexo removido!", "Arquivos desnecessários apagados.", ToolTipIcon.Info);
                    //}
                    //if (frm_Detalhes.instancia != null)
                    //{
                    //    while (!Forms_Controller.pode_desconectar) ;
                    //    frm_Detalhes.instancia.Load_Anexos();
                    //}
                }
                catch { }

                //if (keep_running) { Start_Thread(new Thread(() => Start_Anexo_Delete_Watch())); }
                //Stop_Thread(Thread.CurrentThread);
            }
        }
        public static void Watch_UserLogoff()
        {
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>()
                .Match(change => change.OperationType == ChangeStreamOperationType.Delete);

            using (var cursor = collection_logged_users.Watch(pipeline))
            {
                try
                {
                    while (cursor.MoveNext() && cursor.Current.Count() == 0 && keep_running) { }

                    //if (cursor.Current.First().DocumentKey["_id"].ToString() == id_user_logged)
                    //{
                    //    while (!Forms_Controller.pode_desconectar) ;
                    //    frm_Menu.instancia.Desconectar();
                    //}
                }
                catch { }
                //if (keep_running) { Start_Thread(new Thread(() => Start_UserLogged_Delete_Watch())); }
                //Stop_Thread(Thread.CurrentThread);
            }
        }

        public static bool Conectado_A_Internet()
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com");

            try
            {
                using (var response = myWebRequest.GetResponse()) { }
                return true;
            }
            catch { return false; }
        }

        public static void Show_Net_Error()
        {
            //Forms_Controller.pode_desconectar = false;
            //MessageBox.Show("Sua conexão caiu!\n\nVerifique sua internet\ne tente novamente...", "Falha:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Forms_Controller.pode_desconectar = true;
        }
        public static void Show_Net_Start_Error()
        {
            //MessageBox.Show("Não foi possível se conectar!\n\nVerifique sua conexão...", "Falha:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public async void Send_Email(User user, string email_destino, string assunto, string descrição)
        {
            bool enviada;
            if (Conectado_A_Internet())
            {
                //MessageBox.Show("Enviando solicitação\nde acesso!", "Enviando...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    MailMessage e_mail = new MailMessage(Sys_Email.email, email_destino);
                    e_mail.Subject = assunto;
                    e_mail.SubjectEncoding = Encoding.UTF8;
                    e_mail.IsBodyHtml = false;
                    e_mail.Body = "Usuário: " + user.Nome + "\nContato: " + user.Email + "\nCategoria: " + Controller.Credenciais[Math.Abs(user.Credencial)] + "\n\n" + descrição;
                    e_mail.BodyEncoding = Encoding.UTF8;
                    e_mail.Priority = System.Net.Mail.MailPriority.High;
                    SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(Sys_Email.email, Sys_Email.senha);

                    await smtp.SendMailAsync(e_mail);
                    enviada = true;
                }
                catch { enviada = false; }
                if (enviada)
                {
                    //MessageBox.Show("Recebemos sua requisição.\nAguarde pela liberação.\n\nObrigado pela paciência!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("Não foi possivel solicitar.\nVerifique sua conexão com a internet." +
                    //    "Tente novamente mais tarde!", "Falha:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { Show_Net_Error(); }
        }
        static public async void Send_Verification(string cod, string email_destino)
        {
            bool enviada;
            if (Conectado_A_Internet())
            {
                //MessageBox.Show("Enviando código\nde verificação!", "Enviando...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    MailMessage e_mail = new MailMessage(Sys_Email.email, email_destino);
                    e_mail.Subject = "Código de Verificação";
                    e_mail.SubjectEncoding = Encoding.UTF8;
                    e_mail.IsBodyHtml = false;
                    e_mail.Body = "CÓDIGO: " + cod;
                    e_mail.BodyEncoding = Encoding.UTF8;
                    e_mail.Priority = System.Net.Mail.MailPriority.High;
                    SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(Sys_Email.email, Sys_Email.senha);

                    await smtp.SendMailAsync(e_mail);
                    enviada = true;
                }
                catch { enviada = false; }
                if (enviada)
                {
                    //MessageBox.Show("Código enviado!.\nVerifique sua caixa de e-mails!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("Não foi possivel enviar seu código.\nVerifique sua conexão com a internet\nou tente com outro e-mail mais tarde!",
                    //    "Falha:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { Show_Net_Error(); }
        }
        public static string Verify_User_Email(User user)
        {
            string result = "";
            try
            {
                //MailServer oServer = new MailServer("imap-mail.outlook.com",
                //        Data_Controller.Sys_Email.email,
                //        Data_Controller.Sys_Email.senha,
                //        ServerProtocol.Imap4);

                //oServer.SSLConnection = true;
                //oServer.Port = 993;

                //MailClient oClient = new MailClient("TryIt");
                //oClient.Connect(oServer);

                //MailInfo[] infos = oClient.GetMailInfos();
                //for (int i = 0; i < infos.Length; i++)
                //{
                //    MailInfo info = infos[i];

                //    Mail oMail = oClient.GetMail(info);

                //    if (oMail.Subject.Contains(user.Id))
                //    {
                //        result = oMail.TextBody.ToUpper().Contains("SIM") ? "SIM" : "NÃO";
                //        oClient.Delete(info);
                //        break;
                //    }
                //}
                //oClient.Quit();
            }
            catch { }
            return result;
        }


    }
}
