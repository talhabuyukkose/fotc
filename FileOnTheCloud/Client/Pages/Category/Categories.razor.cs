using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Pages.Category
{

    public partial class Categories
    {
        List<FileOnTheCloud.Shared.DbModel.Category> category = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category1 = new(); 
        List<FileOnTheCloud.Shared.DbModel.Category> category2 = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category3 = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category4 = new();
        FileOnTheCloud.Shared.DbModel.Category selectedcategory = new();

        protected override async Task OnInitializedAsync()
        {
            
                category = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.Category>("api/category/get");

                category1 = category.Where(w => w.parentlevel == 1).ToList();
            
        }
        void Change1(MudListItem response)
        {
            var test = response.Value.ToString();
            //category2 = category.Where(w => w.parentid.ToString() == response).ToList();
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
    }
}
