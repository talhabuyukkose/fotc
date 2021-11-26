using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FileOnTheCloud.Client.Pages.User
{
    public partial class AddorUpdate
    {
        [CascadingParameter]
        IModalService modal { get; set; }

        [Parameter]
        public int userid { get; set; }

        string pagetitle = "Yeni Kullanıcı Oluştur";

        private string token;

        FileOnTheCloud.Shared.DbModel.User _usermodel = new();

        protected override async Task OnInitializedAsync()
        {
            token = await _sessionStorage.GetItemAsync<string>("authToken");

            if (userid != 0)
            {
                try
                {
                    pagetitle = "Kullanıcı Düzenle";

                    HttpResponseMessage httpResponse = await _httpclient.GetAsync($"api/user/getbyid/{userid}");

                    var test = httpResponse.Content.ReadAsStringAsync();
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                        modal.Show<FileOnTheCloud.Client.CustomComponents.LoginComponent.Login>("Giriş");
                    }
                    else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        await modalManager.ShowMessageAsync("Bilgi", $"Kullanıcı bilgileri getirilemedi !{Environment.NewLine}{httpResponse.ReasonPhrase}");
                    }
                    else
                    {
                        var response = await httpResponse.Content.ReadFromJsonAsync<FileOnTheCloud.Shared.DbModel.User>();

                        _usermodel = response;
                    }
                }
                catch (Exception ex)
                {

                    await modalManager.ShowMessageAsync("Hata Mesajı", ex.Message);
                }
            }



        }

        async Task AddorUpdateUser()
        {
            _usermodel.role = "kullanıcı";

            HttpResponseMessage httpResponse = await _httpclient.PostAsJsonAsync($"api/user/set", _usermodel);

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                modal.Show<FileOnTheCloud.Client.CustomComponents.LoginComponent.Login>("Giriş");
            }
            else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"{_usermodel.name} {_usermodel.surname} isimli kullanıcı "
                    + (userid == 0 ? "eklenemedi" : "güncellenemedi"
                    + Environment.NewLine
                    + httpResponse.ReasonPhrase
                    ));
            }
            else if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"{_usermodel.name} {_usermodel.surname} isimli kullanıcı " + (userid == 0 ? "eklendi" : "güncellendi"));

                GotoUserPage();
            }

        }

        #region Navigation

        void GotoUserPage()
        {
            navigation.NavigateTo("/user/users");
        }

        #endregion


        async Task<FileOnTheCloud.Shared.DbModel.User> GetUserAsync(int userId)
        {
            _httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage httpResponse = await _httpclient.GetAsync($"api/user/get/{userId}");

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                modal.Show<FileOnTheCloud.Client.CustomComponents.LoginComponent.Login>("Giriş");
            }
            else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Kullanıcı bilgileri getirilemedi !{Environment.NewLine}{httpResponse.ReasonPhrase}");
            }
            else
            {
                var response = await httpResponse.Content.ReadFromJsonAsync<List<FileOnTheCloud.Shared.DbModel.User>>();

                return response.First();
            }

            return new FileOnTheCloud.Shared.DbModel.User();
        }

    }
}
