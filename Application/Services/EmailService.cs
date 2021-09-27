using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmailService
    {
        public static void Send(string to, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("Smtp.gmail.com");

            mail.From = new MailAddress("ghahveye.ir@gmail.com", "قهوه یه");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpServer.Host = "smtp.iran.liara.ir";
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("ghahveye", "GhahveyeMaAliVaBeht4rinStarTu54st!@#$");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }

}
