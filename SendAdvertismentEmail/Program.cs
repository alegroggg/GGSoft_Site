using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SendAdvertismentEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"E:\firmyGdanskEmails2.txt");

            int emailCount = 0;
            foreach (var line in lines)
            {
                try
                {
                    emailCount++;
                    Console.WriteLine(emailCount + " of " + lines.Length);

                    if (emailCount <= 55)
                    {
                        continue;
                    }

                    MailMessage mail = new MailMessage(new MailAddress("office@ggsoft.pl","GGSoft"), new MailAddress (line));
                    SmtpClient client = new SmtpClient();
                    client.Port = 25;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("office@alegroggg.nazwa.pl", "xyz");
                    client.Host = "alegroggg.nazwa.pl";
                    mail.Subject = "Projektujemy serwisy internetowe oraz aplikacje";
                    mail.Body = System.IO.File.ReadAllText(@"E:\Free Email Templates - 99designs\Free Email Templates - 99designs\Grey\PROMO GREY - GG Soft\PROMO GREY.html");
                    mail.IsBodyHtml = true;
                    client.Send(mail);

                    Thread.Sleep(2000);
                }
                catch
                {

                }
            }   
        }
    }
}
