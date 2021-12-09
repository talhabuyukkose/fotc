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


        private bool _processing = false;

        async Task Upload()
        {
            _processing = true;

            await UploadFiles();

            _processing = false;
        }

        async Task UploadFiles()
        {

            foreach (var item in files)
            {

                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;

                Snackbar.Add($"{item.Name} yükleniyor...", Severity.Info);

                var savingfile = new FileOnTheCloud.Shared.DbModel.SavedFile()
                {
                    filename = item.Name,
                    filesize = item.Size.ToString(),
                    useremail = email,
                    department = category2.First().categoryparentname,
                    grade = category3.First().categoryparentname,
                    semester = selectedcategory.categoryparentname,
                    midtermandfinal = selectedcategory.categoryname,
                    filepath = selectedcategory.categorypath + "/" + selectedcategory.categoryname,
                    fileextension = item.Name.Split('.').Last(),
                    contenttype = item.ContentType
                };

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
                    new KeyValuePair<string,string>("fileextension",savingfile.fileextension),
                    new KeyValuePair<string,string>("contenttype",savingfile.contenttype)
                };


                MemoryStream ms = new MemoryStream();
                await item.OpenReadStream(1048576000).CopyToAsync(ms);

                var multipartContent = new MultipartFormDataContent();

                var byteArrayContent = new ByteArrayContent(ms.ToArray());

                multipartContent.Add(byteArrayContent, "formfile", item.Name);

                foreach (var pair in formUrlEncodedContent)
                {
                    multipartContent.Add(new StringContent(pair.Value), $"\"{pair.Key}\"");
                }

                string errormessage = "Dosya yükleme esnasında bir hata oluştu ! Yönetici ile iletişime geçiniz !";
                string successmessage = "Dosya yükleme başarılı !";

                var response = await helper.PostFileTsAsync("api/savedfile/SetFile", multipartContent, errormessage, successmessage);

                if (response == System.Net.HttpStatusCode.OK)
                {
                    fileNames.Remove(savingfile.filename);

                    Snackbar.Add($"{savingfile.filename} Yüklendi !", Severity.Success);
                }
            }
        }


        void Clear()
        {
            fileNames.Clear();
        }
    }
}
