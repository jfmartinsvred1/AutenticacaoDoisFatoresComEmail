﻿using AutenticacaoComEmail.Data.Ef;
using System.Net;
using System.Net.Mail;

namespace AutenticacaoComEmail.Services
{
    public class Email
    {
        AppDbContext _context;
        public Email(string provedor, string userName, string password)
        {
            Provedor = provedor;
            UserName = userName;
            Password = password;
        }

        public string Provedor { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void SendEmail(string emailsTo)
        {
            var message = PreparandoEmail(emailsTo);
            SendEmailBtSmtp(message);
        }

        private MailMessage PreparandoEmail(string emailsTo)
        {
            var mail = new MailMessage();

            mail.From = new MailAddress(UserName);

            mail.To.Add(emailsTo);

            mail.Subject = "Meriva é gay ";
            mail.Body = "està é a senha da minha piroca "+generateCode();
            mail.IsBodyHtml=true;

            return mail;
        }

        private string generateCode()
        {
            string code = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);

            return code;
        }

        private void SendEmailBtSmtp(MailMessage mail)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = Provedor;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 5000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(UserName, Password);
            smtpClient.Send(mail);
            smtpClient.Dispose();
        }
        
    }
}
