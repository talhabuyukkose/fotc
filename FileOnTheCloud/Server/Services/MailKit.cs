using FileOnTheCloud.Shared.Model;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using System;
using MailKit.Security;

namespace FileOnTheCloud.Server.Services
{
    public class MailKit : IMailService
    {
        private readonly MailSetting _mailSetting;
        public MailKit(IOptions<MailSetting> mailSettings)
        {
            _mailSetting = mailSettings.Value;
        }
        public Task SendEmailAsync(MailRequest mailRequest)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(_mailSetting.Mail, _mailSetting.Mail);

            message.From.Add(from);

            foreach (var address in (mailRequest.ToEmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)))
            {
                MailboxAddress to = new MailboxAddress("User", address);
                message.To.Add(to);
            }
            message.Subject = mailRequest.Subject;


            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<html><body><center><br><hr><br>{mailRequest.Body}<br/></center><hr><b>Akare Copy & Design Center </b><font color=red>tarafından gönderildi. </font></body></html>\r\n";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
                client.Authenticate(_mailSetting.Mail, _mailSetting.Password);
                //client.SslProtocols = System.Security.Authentication.SslProtocols.Tls13;

                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }

            return Task.CompletedTask;
        }
    }
}
