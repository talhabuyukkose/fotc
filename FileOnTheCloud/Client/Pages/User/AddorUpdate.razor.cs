using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

namespace FileOnTheCloud.Client.Pages.User
{
    public partial class AddorUpdate
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        [CascadingParameter]
        IModalService modal { get; set; }

        private string email;

        FileOnTheCloud.Shared.Model.MailRequest mail = new FileOnTheCloud.Shared.Model.MailRequest();

        [Parameter]
        public int userid { get; set; }

        string pagetitle = "Yeni Kullanıcı Oluştur";

        FileOnTheCloud.Shared.DbModel.User _usermodel = new();

        protected override async Task OnInitializedAsync()
        {
            var authstate = await AuthState;

            if (authstate.User.Identity.IsAuthenticated)
            {
                email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;
                if (userid != 0)
                {
                    pagetitle = "Kullanıcı Düzenle";

                    string errormessage = "Bir sorun ile karşılaştık. Lütfen yönetici ile iletişime geçiniz ! ";

                    _usermodel = await helper.GetTsAsync<FileOnTheCloud.Shared.DbModel.User>($"api/user/getbyid/{userid}", errormessage);
                }
            }
        }

        async Task AddorUpdateUser()
        {
            _usermodel.role = "kullanıcı";

            var response = await helper.PostTsAsync<FileOnTheCloud.Shared.DbModel.User>(
                 $"api/user/set", _usermodel
                , $"{_usermodel.name} {_usermodel.surname} isimli kullanıcı " + (userid == 0 ? "eklenemedi" : "güncellenemedi")
                , $"{_usermodel.name} {_usermodel.surname} isimli kullanıcı " + (userid == 0 ? "eklendi" : "güncellendi")
                );

            if (response == System.Net.HttpStatusCode.OK)
            {
                if (_usermodel.id == 0)
                {
                    await SendNotification(email
                        , _usermodel.emailaddress
                        ,$"Merhaba  Sn. {_usermodel.title} {_usermodel.name} {_usermodel.surname}{Environment.NewLine}{Environment.NewLine} https://www.akarecopy.com sistemimizde kullanıcınız oluşturuldu." +
                        $"{Environment.NewLine}\t Sistemimize hoşgeldiniz." +
                        $"{Environment.NewLine} Kullanıcı adınız :\"{_usermodel.emailaddress}\"" +
                        $"{Environment.NewLine} Şifre : {_usermodel.password}" +
                        $"{Environment.NewLine}{Environment.NewLine} İyi günler diliyoruz.");
                }

                GotoUserPage();
            }
        }
      
        async Task SendNotification(string fromemail, string toemail, string body)
        {

            mail.ToEmail = toemail;
            mail.FromEmail = fromemail;
            mail.Subject = "Gönderen :" + fromemail;
            mail.replyid = 0;
            mail.Body = body;
            var httpResponse = await _httpclient.PostAsJsonAsync("api/notification/send", mail);

            if (httpResponse.IsSuccessStatusCode == false)
            {
                Console.WriteLine($"Status : {httpResponse.StatusCode} Message : {httpResponse.Content}");
            }

            var httpContent = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Mesajınız iletildi.");
            }
            else
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Mesajınız iletilirken bir hata oluştu.");
            }
        }

        #region Navigation
        void GotoUserPage()
        {
            navigation.NavigateTo("/user/users");
        }
        #endregion

    }
}
