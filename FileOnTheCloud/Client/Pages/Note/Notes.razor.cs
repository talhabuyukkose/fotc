using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.ComponentModel;

namespace FileOnTheCloud.Client.Pages.Note
{
    public partial class Notes
    {
        List<FileOnTheCloud.Shared.DbModel.SavedFile> savedFiles = new List<FileOnTheCloud.Shared.DbModel.SavedFile>();

        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        private string email;


        FileOnTheCloud.Shared.DbModel.User user = new();

        protected override async Task OnInitializedAsync()
        {
            var authstate = await AuthState;

            if (authstate.User.Identity.IsAuthenticated)
            {
                email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;

                string role = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Role).Value;

                string geturl = role == "admin" ? "api/savedfile/get" : $"api/savedfile/getbyuser/{email}";

                savedFiles = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.SavedFile>(geturl);

                foreach (var item in savedFiles)
                {
                    item.filesize = Math.Round(Convert.ToDouble(item.filesize) / 1048576, 4, MidpointRounding.AwayFromZero).ToString().PadLeft(5, '0');
                }
            }
        }

        private FileOnTheCloud.Shared.DbModel.SavedFile selectedItemSavedFile = null;

        private string searchStringSavedFile = string.Empty;
        private bool FilterFuncSavedFile(FileOnTheCloud.Shared.DbModel.SavedFile element) => FilterFuncSavedFile(element, searchStringSavedFile);

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

        protected async Task DeleteNote(FileOnTheCloud.Shared.DbModel.SavedFile file)
        {
            bool confirmed = await modalManager.ConfirmationAsync("Onay bekleniyor", $"{file.filename} silinecek. Onaylıyor musunuz ?");

            if (confirmed)
            {
                var deleteresponse = await helper.PostTsAsync<FileOnTheCloud.Shared.DbModel.SavedFile>($"api/savedfile/delete", file, "Silme başarısız. Tekrar deneyiniz !", $"{file.filename} silindi");

                if (deleteresponse == System.Net.HttpStatusCode.OK)
                {
                    await OnInitializedAsync();
                }
            }
        }
    }
}
