using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Model
{
    public class MsmqModel
    {
        MessageQueue messageQueue = new MessageQueue();

        public void sendDatatoQueue (string token)
        {
            messageQueue.Path = @".\private$\Bills";
            if(!MessageQueue.Exists(messageQueue.Path))
            {
                MessageQueue.Create(messageQueue.Path);
            }
            messageQueue.Formatter = new XmlMessageFormatter( new Type[] {typeof(string) } );
            messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
            messageQueue.Send(token);
            messageQueue.BeginReceive();
            messageQueue.Close();
            
        }

        private void MessageQueue_ReceiveCompleted (object sender, ReceiveCompletedEventArgs e)
        {
            var message = messageQueue.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            var link = "http://localhost:4200/reset/" + token;
            string subject = "Reset Password link";
            string body = "Hi, <br/><br/>we got request for reset your account password . please Click on the below link to reset your password" +
                "<br/><br/><a href=" + link + ">Reset Password Link</a>";
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = subject;
            mailMessage.From = new MailAddress("aniketjiotode75@gmail.com");
            mailMessage.To.Add("aniketjiotode75@gmail.com");
            mailMessage.Body = body;
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("aniketjiotode75@gmail.com", "rrrcshwyepbvoscx"),
                EnableSsl = true
            };
            smtp.Send(mailMessage);
            messageQueue.BeginReceive();
        }

    }
}
