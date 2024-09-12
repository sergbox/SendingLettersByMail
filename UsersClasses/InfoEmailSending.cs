using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendingLettersByMail.UsersClasses
{
    public class InfoEmailSending
    {
        public InfoEmailSending(string smtpClientAdress,
            StringPair emailAdressFrom,
            string emailPassword,
            StringPair emailAdressTo,
            string subject,
            string body)
        {
            SmtpClientAdress = String.IsNullOrWhiteSpace(smtpClientAdress) ?
            throw new Exception("Heльзя вставлять пробелы или пустое значение!") :
            smtpClientAdress;

            EmailAdressFrom = emailAdressFrom ?? throw new ArgumentNullException(nameof(emailAdressFrom));
            EmailPassword = String.IsNullOrWhiteSpace(emailPassword) ?
            throw new Exception("Heльзя вставлять пробелы или пустое значение!") :
            emailPassword;

            EmailAdressTo = emailAdressTo ?? throw new ArgumentNullException(nameof(emailAdressTo));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));

            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public string SmtpClientAdress { get; set; }
        public StringPair EmailAdressFrom { get; set; }
        public string EmailPassword { get; set; }
        public StringPair EmailAdressTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public class StringPair
        {

            public StringPair(string emailAdress, string name)
            {
                EmailAdress = String.IsNullOrWhiteSpace(emailAdress) ?
                throw new Exception("Henb39 BcTasnaTb npo6enbl unu nycTpoe 3HayeHve!") :
                emailAdress;
                Name = String.IsNullOrWhiteSpace(name) ?
                throw new Exception("Henb39 BcTaenatb npo6enbi unu nyctpoe 3HayeHve!") :
                name;
            }
            public string EmailAdress { get; set; }
            public string Name { get; set; }
        }
    }
}
