using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace SendingLettersByMail.UsersClasses
{
    public class SendingEmail
    {
        private InfoEmailSending InfoEmailSending { get; set; }
        public SendingEmail(InfoEmailSending infoEmailSending)
        {
            InfoEmailSending = infoEmailSending
            ?? throw new ArgumentNullException(nameof(infoEmailSending));
        }
        public void Send()
        {
            try
            {
                SmtpClient mySmtpClient =
                    new SmtpClient(InfoEmailSending.SmtpClientAdress);

                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.EnableSsl = true;
                NetworkCredential basicAuthenticationInfo = new
                    NetworkCredential(
                    InfoEmailSending.EmailAdressFrom.EmailAdress,
                    InfoEmailSending.EmailPassword);
                mySmtpClient.Credentials = basicAuthenticationInfo;
                MailAddress from = new MailAddress(
                InfoEmailSending.EmailAdressFrom.EmailAdress,
                InfoEmailSending.EmailAdressFrom.Name);
                MailAddress to = new MailAddress(
                InfoEmailSending.EmailAdressTo.EmailAdress,
                InfoEmailSending.EmailAdressTo.Name);

                MailMessage myMail = new MailMessage(from, to);

                MailAddress replyTo =
                    new MailAddress(InfoEmailSending.EmailAdressFrom.EmailAdress);
                myMail.ReplyToList.Add(replyTo);

                Encoding encoding = Encoding.UTF8;
                myMail.Subject = InfoEmailSending.Subject;
                myMail.SubjectEncoding = encoding;
                myMail.Body = InfoEmailSending.Body;
                myMail.BodyEncoding = encoding;
                mySmtpClient.Send(myMail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
