using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;

namespace FileOnTheCloud.Client.Pages.User
{
    public partial class Users
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        private string email;

        [CascadingParameter]
        IModalService modal { get; set; }


        List<FileOnTheCloud.Shared.DbModel.User> userlist = new List<FileOnTheCloud.Shared.DbModel.User>();

        //private string token;

        protected override async Task OnInitializedAsync()
        {
            //token = await _sessionStorage.GetItemAsync<string>("authToken");
            var authstate = await AuthState;

            if (authstate.User.Identity.IsAuthenticated)
            {
                email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

                string errormessage = "Kullanıcılar listelenirken bir sorun oluştu !";

                userlist = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.User>("api/user/get", errormessage);
            }
        }

        protected void GotoEditUser(int id)
        {
            navigation.NavigateTo($"/user/edituser/{id}");
        }

        protected void goCreateUserPage()
        {
            navigation.NavigateTo($"/user/adduser");
        }

        protected async Task DeleteUser(int Id)
        {
            var deleteresponse = await helper.DeleteTsAsync<FileOnTheCloud.Shared.DbModel.User>($"api/user/delete/{Id}");

            if (deleteresponse == System.Net.HttpStatusCode.OK)
            {
                await OnInitializedAsync();
            }
        }

        async Task SendNotification(string toemail)
        {

            ModalParameters modalParameters = new ModalParameters();

            modalParameters.Add("toemail", toemail);
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
