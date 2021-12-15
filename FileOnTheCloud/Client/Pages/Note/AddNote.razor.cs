using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Pages.Note
{
    public partial class AddNote
    {
        [Parameter]
        public int parentid { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }

        private string email;

        private string title = "Bölümler";

        private bool showuploadpanelon = false;


        List<FileOnTheCloud.Shared.DbModel.Category> category = new();
        FileOnTheCloud.Shared.DbModel.Category selectedcategory = new();


        protected override async Task OnInitializedAsync()
        {
            var authstate = await AuthState;

            if (authstate.User.Identity.IsAuthenticated)
            {
                email = authstate.User.FindFirst(System.Security.Claims.ClaimTypes.Email).Value;
            }

            await GetList();
        }

        public async Task GetList()
        {
            string errormessage = "Üst kategori getirilemedi !";

            var temp = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.Category>($"api/category/getbyparentid/{parentid}", errormessage);

            if (temp.Count == 0)
            {
                await modalManager.ShowMessageAsync("Bilgi", "Lütfen alt kategori ekleyeniz !");
            }
            else
            {
                category = temp;
            }

            title = $"Bölümler {category.First().categorypath.Replace("/", " > ")} >";
        }

        async void GetSubCategory(FileOnTheCloud.Shared.DbModel.Category _category)
        {
            if (_category.parentlevel < 4)
            {
                parentid = _category.id;

                await GetList();

                navigation.NavigateTo($"/note/addnote/{_category.id}");
            }
            else if (_category.parentlevel == 4)
            {
                showuploadpanelon = true;

                selectedcategory = _category;
            }
        }

        async void GetParentCategory()
        {
            if (category.First().parentid != 1)
                showuploadpanelon = false;

            if (category.First().parentlevel > 1)
            {
                string errormessage = "Kategori getirilirken bir sorun oluştu !";
                var response = await helper.GetTsAsync<FileOnTheCloud.Shared.DbModel.Category>($"api/category/getbyid/{category.First().parentid}", errormessage);

                parentid = response.parentid;

                await GetList();

                navigation.NavigateTo($"/note/addnote/{response.parentid}");
            }

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
                    department = selectedcategory.categoryparentpath.Split('/')[1],
                    grade = selectedcategory.categoryparentpath.Split('/')[2],
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
