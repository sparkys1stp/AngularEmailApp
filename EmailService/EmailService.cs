using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using EmailService.Models;

namespace EmailService
{
    public interface IEmailService
    {
        void Email(EmailMessageVM emailVM);
    }

    public class EmailService:IEmailService
    {

        public void Email(EmailMessageVM emailVM)
        {
           
            var razorEngineService = new RazorEngineService();

            var msg = new MailMessage(emailVM.FromEmail, emailVM.ToEmail)
            {
                Subject = emailVM.Subject,
                Body = razorEngineService.ParseEmailTemplate(emailVM),
                IsBodyHtml = true
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Send(msg);
            }

        }


    }
}
