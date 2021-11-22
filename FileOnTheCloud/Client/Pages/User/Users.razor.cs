using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;

namespace FileOnTheCloud.Client.Pages.User
{
    public partial class Users
    {
        [CascadingParameter]
        IModalService modal { get; set; }

        List<FileOnTheCloud.Shared.DbModel.User> userlist = new List<FileOnTheCloud.Shared.DbModel.User>();

        private string token;

        protected override async Task OnInitializedAsync()
        {
            token = await _sessionStorage.GetItemAsync<string>("authToken");

            _httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage httpResponse = await _httpclient.GetAsync($"api/user/get");

            var httpcontent = await httpResponse.Content.ReadAsStreamAsync();

            Console.WriteLine(httpcontent);

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
                userlist = await httpResponse.Content.ReadFromJsonAsync<List<FileOnTheCloud.Shared.DbModel.User>>();
            }

        }


        protected void goUpdateUserPage(int id)
        {
            navigation.NavigateTo($"/user/edituser/{id}");
        }

        protected void goCreateUserPage()
        {
            navigation.NavigateTo($"/user/adduser");
        }

        protected async Task DeleteUser(int Id)
        {
            bool confirmed = await modalManager.ConfirmationAsync("Onay bekleniyor", "Kullanıcı silinecek. Onaylıyor musunuz ?");

            if (!confirmed) return;

            try
            {
                HttpResponseMessage httpResponse = await _httpclient.GetAsync($"User/Delete/{token}/{Id}");

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await modalManager.ShowMessageAsync("Silme", "Kullanıcı silindi ");

                    await OnInitializedAsync();
                }

            }
            catch (HttpRequestException ex)
            {
                await modalManager.ShowMessageAsync("Silme", ex.Message);
            }

        }
    }
}
