using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.Modal;
using System.IdentityModel.Tokens.Jwt;

namespace FileOnTheCloud.Client.Shared
{
    public partial class Sidebar
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        [CascadingParameter]
        IModalService modal { get; set; }

        private string email;

        private string roleName = String.Empty;

        FileOnTheCloud.Shared.DbModel.User user = new();

        private string token;

        protected override async Task OnInitializedAsync()
        {
            var authstate = await AuthState;

            if (authstate.User.Identity.IsAuthenticated)
            {
                email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

                token = await _sessionStorage.GetItemAsync<string>("authToken");

                _httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await _httpclient.GetAsync($"api/user/getbyemail/{email}");

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                    modal.Show<FileOnTheCloud.Client.CustomComponents.LoginComponent.Login>("Giriş");

                }
                else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    await modalManager.ShowMessageAsync("Bilgi", $"Kullanıcılar listelenemedi !{Environment.NewLine}{httpResponse.ReasonPhrase}");
                }
                else
                {
                    user = await httpResponse.Content.ReadFromJsonAsync<FileOnTheCloud.Shared.DbModel.User>();
                }
            }

        }

        protected async Task SendMail()
        {     
            ModalParameters modalParameters = new ModalParameters();

            //modalParameters.Add("toemail", "talha.buyukkose@hotmail.com");
            modalParameters.Add("fromemail", email);
            modalParameters.Add("replyid", 0);

            var response = modal.Show<FileOnTheCloud.Client.CustomComponents.Notification.SendMessage>("Bildirim Gönderimi", modalParameters);

            var result = await response.Result;

            if (!result.Cancelled)
            {
                string temp = result.Data?.ToString() ?? string.Empty;

                if (Convert.ToBoolean(temp))
                {
                    await modalManager.ShowMessageAsync("Bilgi", $"Mesajınız iletildi.");
                }
                else
                {
                    await modalManager.ShowMessageAsync("Bilgi", $"Mesajınız iletilirken bir hata oluştu.");

                }
            }
        }
    }
}
