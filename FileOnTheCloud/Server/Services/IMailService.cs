using FileOnTheCloud.Shared.Model;
using System.Threading.Tasks;

namespace FileOnTheCloud.Server.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}