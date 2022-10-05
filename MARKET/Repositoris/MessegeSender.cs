using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MARKET.Repositoris
{
    public class MessageSender
  {
    public static void Send(string To, string Subject, string Body)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
        mail.From = new MailAddress("fard09378840923@gmail.com", " سایت بازار مبل ملایر");
        mail.To.Add(To);
        mail.Subject = Subject;
        mail.Body = Body;
        mail.IsBodyHtml = true;
        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("fard09378840923@gmail.com", "fard1234");
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
    }

  }

}