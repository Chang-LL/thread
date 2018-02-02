using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
//excetion
namespace MyThread
{
    class LoopingThreads
    {
        public delegate void SendMail(string oMessageTo);
        private class MyMail
        {
            public string EmailTo;
            public string EmailFrom;
            public string EmailSubject;
            public string EmailBody;
            public SendMail SendThisMail;//Delegate instance

            public void Send()
            {
                MailMessage oMail =
                    new MailMessage
                    {
                        Sender = new MailAddress(EmailTo),
                        From = new MailAddress(EmailFrom),
                        Body = EmailBody,
                        Subject = EmailSubject
                    };
                //SmtpMail.Send(oMail);
                SendThisMail(EmailTo);
            }
        }
        public static Thread CreateEmail(SendMail sendMail,
            string emailTo,string emailFrom,
            string emailBody,string emailSubject)
        {
            MyMail myMail = new MyMail
            {
                EmailFrom = emailFrom,
                EmailBody = emailBody,
                EmailSubject = emailSubject,
                EmailTo = emailTo,
                SendThisMail = sendMail
            };

            Thread t = new Thread(new ThreadStart(myMail.Send));
            return t;
        }
        public class Mailer
        {
            public static void MailMethod(string s)
            {
                Console.WriteLine("Sending Email: " + s);
            }
        }
        public class DoMail
        {
            static ArrayList al = new ArrayList();
            public static void Main0()
            {
                for (int i = 1; i <=1000; i++)
                {
                    al.Add(i.ToString() + "@someplace.com");
                }
                SendAllEmail();
            }
            public static void SendAllEmail()
            {
                int loopTo = al.Count - 1;
                for (int i = 0; i <=loopTo; i++)
                {
                    Thread t = CreateEmail(
                        new SendMail(Mailer.MailMethod),
                        (string)al[i],
                        "johndoe@somewhere.com",
                        "Threading in a loop",
                        "Mail Example");
                    t.Start();
                    t.Join(Timeout.Infinite);
                }
            }
        }
    }
}
