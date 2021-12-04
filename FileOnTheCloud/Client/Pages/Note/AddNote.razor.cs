using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using MudBlazor;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Pages.Note
{
    public partial class AddNote
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        private string email;

        List<FileOnTheCloud.Shared.DbModel.Category> category = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category1 = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category2 = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category3 = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category4 = new();
        FileOnTheCloud.Shared.DbModel.Category selectedcategory = new();


        protected override async Task OnInitializedAsync()
        {
            var authstate = await AuthState;

            if (authstate.User.Identity.IsAuthenticated)
            {
                email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;
                category = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.Category>("api/category/get");

                category1 = category.Where(w => w.parentlevel == 1).ToList();
            }
        }
        void Change1(string response)
        {
            category2 = category.Where(w => w.parentid.ToString() == response).ToList();
        }
        void Change2(string response)
        {
            category3 = category.Where(w => w.parentid.ToString() == response).ToList();
        }
        void Change3(string response)
        {
            category4 = category.Where(w => w.parentid.ToString() == response).ToList();
        }
        void Change4(string response)
        {
            selectedcategory = category.Where(w => w.id.ToString() == response).ToList().First();
        }


        string _dragEnterStyle;
        IList<string> fileNames = new List<string>();
        IReadOnlyList<IBrowserFile> files;

        void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            files = e.GetMultipleFiles();
            fileNames = files.Select(f => f.Name).ToList();
        }
        async void Upload()
        {

            foreach (var item in files)
            {
                FileOnTheCloud.Shared.DbModel.SavedFile savingfile = new();

                savingfile.filename = item.Name;
                savingfile.filesize = item.Size.ToString();
                savingfile.useremail = email;
                savingfile.department = category2.First().categoryparentname;
                savingfile.grade = category3.First().categoryparentname;
                savingfile.semester = selectedcategory.categoryparentname;
                savingfile.midtermandfinal = selectedcategory.categoryname;
                savingfile.filepath = selectedcategory.categorypath + "/" + selectedcategory.categoryname;
                savingfile.fileextension = item.Name.Split('.').Last();


                var formUrlEncodedContent = new[]
                {
                    new KeyValuePair<string,string>("filename",savingfile.filename),
                    new KeyValuePair<string,string>("filesize",savingfile.filesize),
                    new KeyValuePair<string,string>("useremail",savingfile.useremail),
                    new KeyValuePair<string,string>("department",savingfile.department),
                    new KeyValuePair<string,string>("grade",savingfile.grade),
                    new KeyValuePair<string,string>("semester",savingfile.semester),
                    new KeyValuePair<string,string>("midtermandfinal",savingfile.midtermandfinal),
                    new KeyValuePair<string,string>("filepath",savingfile.filepath),
                    new KeyValuePair<string,string>("fileextension",savingfile.fileextension)
                };


                MemoryStream ms = new MemoryStream();
                await item.OpenReadStream(104857600).CopyToAsync(ms);

                var multipartContent = new MultipartFormDataContent();

                var byteArrayContent = new ByteArrayContent(ms.ToArray());

                multipartContent.Add(byteArrayContent, "formfile", item.Name);

                foreach (var pair in formUrlEncodedContent)
                {
                    multipartContent.Add(new StringContent(pair.Value), $"\"{pair.Key}\"");
                }

                var response = await helper.PostFileTsAsync("api/savedfile/SetFile", multipartContent, "", "");

                if (response == System.Net.HttpStatusCode.OK)
                {
                    fileNames.Remove(savingfile.filename);

                    Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

                    Snackbar.Add($"{savingfile.filename} Yüklendi", Severity.Normal);


                }

            }

        }
        void Clear()
        {
            fileNames.Clear();
        }
    }
}
