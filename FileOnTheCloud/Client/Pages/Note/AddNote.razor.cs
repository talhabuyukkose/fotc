using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Pages.Note
{
    public partial class AddNote
    {


        List<FileOnTheCloud.Shared.DbModel.Category> category = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category1 = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category2 = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category3 = new();
        List<FileOnTheCloud.Shared.DbModel.Category> category4 = new();
        FileOnTheCloud.Shared.DbModel.Category selectcategory = new();


        protected override async Task OnInitializedAsync()
        {
            category = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.Category>("api/category/get");

            category1 = category.Where(w => w.parentlevel == 1).ToList();
            //category2 = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.Category>("api/category/getbylevel/2");

            //category3 = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.Category>("api/category/getbylevel/3");

            //category4 = await helper.GetListTsAsync<FileOnTheCloud.Shared.DbModel.Category>("api/category/getbylevel/4");
        }

        void Change1(int response)
        {
            category2=category.Where(w=>w.parentid==response).ToList();
        }
        void Change2(int response)
        {
            category3 = category.Where(w => w.parentid == response).ToList();
        }
        void Change3(int response)
        {
            category4 = category.Where(w => w.parentid == response).ToList();
        }
        void Change4(int response)
        {
            selectcategory = category.Where(w => w.parentid == response).ToList().First();
        }
    }
}
