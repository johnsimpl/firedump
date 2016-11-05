using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using static System.Windows.Forms.Control;

namespace Examples.SmptExamples.Async
{
    public class emailform
    {


        

        public static void sendmail(String args,String from, String to)
        {
            SmtpClient smtp = new SmtpClient(args);
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("jichenyang1995@hotmail.com",
              "");
            MailMessage message = new MailMessage();
            message.Sender = new MailAddress("jichenyang1995@hotmail.com",
"Peter Shaw");
            message.From = new MailAddress("jichenyang1995@hotmail.com",
   "Peter Shaw");

            message.To.Add(new MailAddress(to,
               "Recipient Number 1"));
           

            message.Subject = "My HTML Formatted Email";
            message.Body = "<h1>HTML Formatted EMail</h1>< p > DO you like this < strong > EMail </ strong >with HTML formatting contained in its body.</ p > ";


            message.IsBodyHtml = true;
            smtp.Send(message);
        }

        

    }
}
