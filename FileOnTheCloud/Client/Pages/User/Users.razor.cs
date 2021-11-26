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

            userlist = await GetUserListAsync();
        }


        protected void GotoEditUser(int id)
        {
            navigation.NavigateTo($"/user/edituser/{id}");
        }

        protected void goCreateUserPage()
        {
            navigation.NavigateTo($"/user/adduser");
        }

        async Task<List<FileOnTheCloud.Shared.DbModel.User>> GetUserListAsync()
        {

            HttpResponseMessage httpResponse = await _httpclient.GetAsync($"api/user/get");

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                navigation.NavigateTo("/auth/login");

            }
            else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Kullanıcılar listelenemedi !{Environment.NewLine}{httpResponse.ReasonPhrase}");
            }
            else
            {
                return await httpResponse.Content.ReadFromJsonAsync<List<FileOnTheCloud.Shared.DbModel.User>>();
            }

            return new List<FileOnTheCloud.Shared.DbModel.User>();
        }


        protected async Task DeleteUser(int Id)
        {
            bool confirmed = await modalManager.ConfirmationAsync("Onay bekleniyor", "Kullanıcı silinecek. Onaylıyor musunuz ?");

            if (!confirmed) return;

            try
            {
                HttpResponseMessage httpResponse = await _httpclient.DeleteAsync($"api/user/delete/{Id}");

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
