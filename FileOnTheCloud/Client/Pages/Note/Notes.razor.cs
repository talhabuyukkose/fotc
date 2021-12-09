using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.JSInterop;
using MudBlazor;

namespace FileOnTheCloud.Client.Pages.Note
{
    public partial class Notes
    {
        List<FileOnTheCloud.Shared.DbModel.SavedFile> savedFiles = new List<FileOnTheCloud.Shared.DbModel.SavedFile>();

        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        private string email;

        private string role;

        private string geturl;


        FileOnTheCloud.Shared.DbModel.User user = new();

        protected override async Task OnInitializedAsync()
        {
            var authstate = await AuthState;

            if (authstate.User.Identity.IsAuthenticated)
            {
                email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

                role = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Role).Value;

                geturl = role == "admin" ? "api/savedfile/get" : $"api/savedfile/getbyuser/{email}";


                await GetSavedFile(geturl);
                
            }
        }

        async Task GetSavedFile(string geturl)
        {
            savedFiles = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.SavedFile>(geturl);

            foreach (var item in savedFiles)
            {
                item.filesize = Math.Round(Convert.ToDouble(item.filesize) / 1048576, 3, MidpointRounding.AwayFromZero).ToString().PadLeft(5, '0');
            }
        }


        private FileOnTheCloud.Shared.DbModel.SavedFile selectedItemSavedFile = null;

        private string searchStringSavedFile = string.Empty;
        private bool FilterFuncSavedFile(FileOnTheCloud.Shared.DbModel.SavedFile element) => FilterFuncSavedFile(element, searchStringSavedFile);


        protected async Task DeleteNote(FileOnTheCloud.Shared.DbModel.SavedFile file)
        {
            bool confirmed = await modalManager.ConfirmationAsync("Onay bekleniyor", $"{file.filename} silinecek. Onaylıyor musunuz ?");

            if (confirmed)
            {
                string errormesage = "Silme başarısız. Tekrar deneyiniz !";

                string succesmessage = $"{file.filename} silindi";

                var deleteresponse = await helper.PostTsAsync<FileOnTheCloud.Shared.DbModel.SavedFile>($"api/savedfile/delete", file, errormesage, succesmessage);

                if (deleteresponse == System.Net.HttpStatusCode.OK)
                {
                    await GetSavedFile(geturl);
                }
            }
        }

        protected async Task DownloadNote(FileOnTheCloud.Shared.DbModel.SavedFile file)
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

            Snackbar.Add($"{file.filename} indiriliyor...", Severity.Info);

            string errormesage = "Dosya sunucudan getirilemedi. Lütfen tekrar deneyiniz veya yönetici ile iletişime geçiniz.";

            string succesmessage = "Dosya getirildi";

            var response = await helper.PostReturnValueTsAsync<FileOnTheCloud.Shared.DbModel.SavedFile>("api/savedfile/getfile", file, errormesage, succesmessage);


            await JsRuntime.InvokeVoidAsync("downloadFile", file.contenttype, response, file.filename);

            Snackbar.Add($"{file.filename} indirildi !", Severity.Success);

        }
       
        private bool FilterFuncSavedFile(FileOnTheCloud.Shared.DbModel.SavedFile element, string searchStringsavedFile)
        {
            if (string.IsNullOrWhiteSpace(searchStringsavedFile))
                return true;
            if (element.filename.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.department.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.grade.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.semester.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.midtermandfinal.Contains(searchStringsavedFile, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}

