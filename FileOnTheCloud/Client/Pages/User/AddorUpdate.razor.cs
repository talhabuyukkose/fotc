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
        [Parameter]
        public int userid { get; set; }

        string pagetitle = "Yeni Kullanıcı Oluştur";

        FileOnTheCloud.Shared.DbModel.User _usermodel = new();

        protected override async Task OnInitializedAsync()
        {
            if (userid != 0)
            {
                pagetitle = "Kullanıcı Düzenle";

                _usermodel = await helper.GetTsAsync<FileOnTheCloud.Shared.DbModel.User>($"api/user/getbyid/{userid}");
            }
        }

        async Task AddorUpdateUser()
        {
            _usermodel.role = "kullanıcı";

            var response = await helper.PostTsAsync<FileOnTheCloud.Shared.DbModel.User>(
                _usermodel, $"api/user/set"
                , $"{_usermodel.name} {_usermodel.surname} isimli kullanıcı " + (userid == 0 ? "eklenemedi" : "güncellenemedi")
                , $"{_usermodel.name} {_usermodel.surname} isimli kullanıcı " + (userid == 0 ? "eklendi" : "güncellendi")
                );

            if(response==System.Net.HttpStatusCode.OK)
            {
                GotoUserPage();
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
