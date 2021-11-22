using FileOnTheCloud.Shared.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Authentication
{
    public interface IAuthenticationService
    {
        Task<HttpResponseMessage> Login(Login loginmodel);
        Task Logout();
    }
}