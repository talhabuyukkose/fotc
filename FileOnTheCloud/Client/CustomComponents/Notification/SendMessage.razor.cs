using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.CustomComponents.Notification
{
    public partial class SendMessage
    {

        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; }

        FileOnTheCloud.Shared.Model.MailRequest Request = new FileOnTheCloud.Shared.Model.MailRequest();
        private async Task SendMail()
        {
            JwtSecurityToken securityToken = new();

            var token = await _sessionStorage.GetItemAsync<string>("authToken");

            securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var email = securityToken.Claims.Where(w => w.Type == "email").FirstOrDefault().Value;

            Request.FromEmail = email;
            Request.Subject = "Gönderen :" + email;

            var httpResponse = await _httpclient.PostAsJsonAsync("api/notification/sendtoadmin", Request);

            if (httpResponse.IsSuccessStatusCode == false)
            {
                Console.WriteLine($"Status : {httpResponse.StatusCode} Message : {httpResponse.Content}");
            }

            var httpContent = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await BlazoredModal.CloseAsync(ModalResult.Ok(true));
            }
            else
            {
                await BlazoredModal.CloseAsync(ModalResult.Ok(false));
            }
        }
    }
}
