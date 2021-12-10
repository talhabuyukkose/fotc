using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Pages.Notification
{
    public partial class Notifications
    {
        List<FileOnTheCloud.Shared.Model.GetNotification_WithEmail> notifications = new();

        [CascadingParameter]
        IModalService modal { get; set; }

        private string email;

        private string token;
        protected override async Task OnInitializedAsync()
        {
            JwtSecurityToken securityToken = new();

            token = await _sessionStorage.GetItemAsync<string>("authToken");

            securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            email = securityToken.Claims.Where(w => w.Type == "email").FirstOrDefault().Value;

            await GetNotifications();


        }

        async Task GetNotifications()
        {
            string errormessage = "Bildirim listenelemedi !";

            notifications = await helper.GetListTsAsync<FileOnTheCloud.Shared.Model.GetNotification_WithEmail>($"api/notification/getbyemail/{email}", errormessage);
        }

        async Task Seen(FileOnTheCloud.Shared.Model.GetNotification_WithEmail getNotification)
        {
            string errormessage = "Bildirim görüldü işaretlenemedi";

            string successmessage = "İşlem Tamamlandı";

            var response = await helper.PostTsAsync<FileOnTheCloud.Shared.Model.GetNotification_WithEmail>("api/notification/seen", getNotification, errormessage, successmessage);

            await GetNotifications();
        }

        async Task SendReply(FileOnTheCloud.Shared.Model.GetNotification_WithEmail getNotification)
        {

            ModalParameters modalParameters = new ModalParameters();

            modalParameters.Add("toemail", getNotification.frommail);
            modalParameters.Add("fromemail", email);
            modalParameters.Add("replyid", getNotification.id);

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

        private FileOnTheCloud.Shared.Model.GetNotification_WithEmail selectedItemNotification = null;

        private string searchStringNotification = string.Empty;
        private bool FilterFuncNotication(FileOnTheCloud.Shared.Model.GetNotification_WithEmail element) => FilterFuncNotication(element, searchStringNotification);

        private bool FilterFuncNotication(FileOnTheCloud.Shared.Model.GetNotification_WithEmail element, string searchStringNotification)
        {
            if (string.IsNullOrWhiteSpace(searchStringNotification))
                return true;
            if (element.message.Contains(searchStringNotification, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.frommail.Contains(searchStringNotification, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

    }
}
