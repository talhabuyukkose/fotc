using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Pages.Category
{

    public partial class Categories
    {
        [Parameter]
        public int parentid { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> AuthState { get; set; }


        private string email;

        private bool editOn = false;

        private bool addSubCategoryOn = false;

        private bool addCategoryOn = false;

        private string title = "Bölümler";

        private string _addcategoryname = "";

        List<FileOnTheCloud.Shared.DbModel.Category> category = new();

        FileOnTheCloud.Shared.DbModel.Category _addsubcategory = new();

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
            var temp = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.Category>($"api/category/getbyparentid/{parentid}");

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

        private void rowEditCommit(object _category)
        {
            var temp = _category;
        }

        async void GetSubCategory(FileOnTheCloud.Shared.DbModel.Category _category)
        {
            if (_category.parentlevel < 4)
            {
                parentid = _category.id;

                await GetList();

                navigation.NavigateTo($"/category/categories/{_category.id}");
            }
        }
        async void GetParentCategory(string _title)
        {
            if (category.First().parentlevel > 1)
            {
                var response = await helper.GetTsAsync<FileOnTheCloud.Shared.DbModel.Category>($"api/category/getbyid/{category.First().parentid}");

                parentid = response.parentid;

                await GetList();

                navigation.NavigateTo($"/category/categories/{response.parentid}");
            }

        }

        void AddSubCategory(FileOnTheCloud.Shared.DbModel.Category _category)
        {
            addSubCategoryOn = true;
            _addsubcategory = _category;
        }

        async Task _AddSubCategory(string _title)
        {
            FileOnTheCloud.Shared.DbModel.Category _category = new()
            {
                useremail = email,

                categoryname = _addcategoryname,

                categorypath = _addsubcategory.categorypath + "/" + _addsubcategory.categoryname,

                categoryparentname = _addsubcategory.categoryname,

                categoryparentpath = _addsubcategory.categorypath,

                parentid = _addsubcategory.id,

                parentlevel = _addsubcategory.parentlevel + 1,
            };

            string successmessage = "Kategori eklendi !";

            string errormessage = "Kategori eklenirken bir hata oluştu !";

            var response = await helper.PostTsAsync<FileOnTheCloud.Shared.DbModel.Category>("api/category/set", _category, errormessage, successmessage);

            _addcategoryname=String.Empty;

            addSubCategoryOn = false;
        }


        void AddCategory(string title)
        {
            addCategoryOn = true;
        }

        async Task _AddCategory(string title)
        {
            FileOnTheCloud.Shared.DbModel.Category _category = new()
            {
                useremail = email,

                categoryname = _addcategoryname,

                categorypath = "",

                categoryparentname = "",

                categoryparentpath = "",

                parentid = 0,

                parentlevel = 1,
            };

            string successmessage = "Kategori eklendi !";

            string errormessage = "Kategori eklenirken bir hata oluştu !";

            await helper.PostTsAsync<FileOnTheCloud.Shared.DbModel.Category>("api/category/set", _category, errormessage, successmessage);

            _addcategoryname = String.Empty;

            addCategoryOn = false;

            await GetList();
        }

    }
}
