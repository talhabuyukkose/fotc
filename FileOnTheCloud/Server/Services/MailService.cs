using FileOnTheCloud.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace FileOnTheCloud.Server.Services
{
    public class MailService : IMailService
    {
        private readonly MailSetting _mailSetting;
        public MailService(IOptions<MailSetting> mailSettings)
        {
            _mailSetting = mailSettings.Value;
        }
        public Task SendEmailAsync(MailRequest mailRequest)
        {
            var message = new MailMessage()
            {
                Subject = mailRequest.Subject,

                Body = mailRequest.Body,

                From = new MailAddress(_mailSetting.Mail)
            };

            foreach (var address in (mailRequest.ToEmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)))
            {
                message.To.Add(address);
            }

            using (var smtp = new SmtpClient())
            {
                smtp.Host = _mailSetting.Host;

                smtp.Port = _mailSetting.Port;

                smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new NetworkCredential(_mailSetting.Mail, _mailSetting.Password);

                smtp.Send(message);
            }

            return Task.CompletedTask;
        }
    }
}
