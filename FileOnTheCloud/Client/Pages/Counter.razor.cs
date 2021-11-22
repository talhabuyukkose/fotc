using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        private string response = string.Empty;

        private void IncrementCount()
        {
            currentCount++;
        }

        private async Task Login()
        {
            FileOnTheCloud.Shared.Model.Login user = new FileOnTheCloud.Shared.Model.Login();

            user.username = "talha.buyukkose@hotmail.com";

            user.password = "123456";

            var httpResponse = await _httpclient.PostAsJsonAsync("api/auth/login", user);

            var httpContent = await httpResponse.Content.ReadAsStringAsync();

            response = httpContent;


        }

        FileOnTheCloud.Shared.Model.MailRequest Request = new FileOnTheCloud.Shared.Model.MailRequest();
        private async Task mailtest()
        {
            JwtSecurityToken securityToken = new();

            var token = await _sessionStorage.GetItemAsync<string>("authToken");

            securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var email = securityToken.Claims.Where(w => w.Type == "email").FirstOrDefault().Value;

            Request.FromEmail = email;
            Request.ToEmail = "talha.buyukkose@hotmail.com";
            Request.Subject = "Gönderen :" + email;

            var httpResponse = await _httpclient.PostAsJsonAsync("api/notification/send", Request);

            if (httpResponse.IsSuccessStatusCode == false)
            {
                Console.WriteLine($"Status : {httpResponse.StatusCode} Message : {httpResponse.Content}");
            }
            var httpContent = await httpResponse.Content.ReadAsStringAsync();

            response = httpContent;
        }

        private async Task GetNotification()
        {
            JwtSecurityToken securityToken = new();

            var token = await _sessionStorage.GetItemAsync<string>("authToken");

            securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var email = securityToken.Claims.Where(w => w.Type == "email").FirstOrDefault().Value;

            var httpResponse = await _httpclient.PostAsJsonAsync("api/notification/get", email);

            var httpContent = await httpResponse.Content.ReadAsStringAsync();

            response = httpContent;
        }

    }
}
