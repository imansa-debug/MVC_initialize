using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public interface IMailSender: IGmailSender
    {
    }

    public interface IGmailSender
    {
        void SendGmail(string To, string Subject, string Body);
    }

    public class SendMail : IMailSender
    {
        public void SendGmail(string To, string Subject, string Body)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("imansafari33@gmail.com", "تاپ لرن");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("imansafari33@gmail.com", "Iiiglkisdofllci8644784-775");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
