using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net; 
using System.Threading;

namespace ConsoleApp348
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer sendMailTimer = new Timer(SendMailCallBack, "Email Test", 0, 1000);
            Console.ReadLine();
        }

        private static void SendMailCallBack(object state)
        {
            MailExample();
        }

        static void MailExample()
        {
            string fromEmail = "from@frommail.com";
            string toEmail = "to@tomail.com";
            string fromEmailPwd = "frommailpwd";
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.163.com";                
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(fromEmail, fromEmailPwd);

                MailMessage mail = new MailMessage();
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(new MailAddress(toEmail));
                mail.Subject = $"Cloud,I love you.This is from my own program.Now is {DateTime.Now.ToString("mmssffff")}";
                mail.Body = $"This is the mail body,And now is {DateTime.Now.ToString("yyyyMMddHHmmssffff")}";
                smtpClient.Send(mail);
                Console.WriteLine("Succeed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
