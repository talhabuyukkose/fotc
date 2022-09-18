using FileOnTheCloud.Shared.Model;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FileOnTheCloud.Server.Services
{
    public class Outlook : IMailService
    {
        private readonly MailSetting _mailSetting;
        public Outlook(IOptions<MailSetting> mailSettings)
        {
            _mailSetting = mailSettings.Value;
        }

        public Task SendEmailAsync(MailRequest mailRequest)
        {
            var mailMessage = new MailMessage()
            {
                Subject = mailRequest.Subject,
                From = new MailAddress(_mailSetting.Mail),
                Body = $"<html><body><center><br><hr><br>{mailRequest.Body}<br/></center><hr><b>Akare Copy & Design Center </b><font color=red>tarafından gönderildi. </font></body></html>",
                BodyEncoding = System.Text.Encoding.UTF8,
                Priority = MailPriority.Normal,
                IsBodyHtml = true

            };

            foreach (var address in (mailRequest.ToEmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)))
            {
                mailMessage.To.Add(address);
            }


            using (var smtp = new SmtpClient())
            {
                smtp.Host = _mailSetting.Host;
                smtp.Port = _mailSetting.Port;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_mailSetting.Mail, _mailSetting.Password);

                try
                {
                    smtp.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
            mailMessage.Dispose();


            return Task.CompletedTask;
        }
    }
}

