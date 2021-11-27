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

        //private string token;

        protected override async Task OnInitializedAsync()
        {
            //token = await _sessionStorage.GetItemAsync<string>("authToken");

            userlist = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.User>("api/user/get");
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
    }
}
