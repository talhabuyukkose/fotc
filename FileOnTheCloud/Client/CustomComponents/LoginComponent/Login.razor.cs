using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.CustomComponents.LoginComponent
{
    public partial class Login
    {
        private FileOnTheCloud.Shared.Model.Login loginmodel = new();

        private async Task ExecuteLogin()
        {
            try
            {
                HttpResponseMessage httpResponse = await AuthService.Login(loginmodel);

                var httpContent = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await modalManager.ShowMessageAsync("", "Kullanıcı bilgilerini kontrol edip yeniden deneyiniz !");
                }
                else if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    FileOnTheCloud.Shared.Model.Authenticated authenticated = System.Text.Json.JsonSerializer.Deserialize<FileOnTheCloud.Shared.Model.Authenticated>(httpContent);

                    Console.WriteLine("Login Success");

                    navigation.NavigateTo("/");
                }
            }
            catch (Exception ex)
            {
                await modalManager.ShowMessageAsync("", "Kullanıcı bilgilerini kontrol edip yeniden deneyiniz !");

                Console.WriteLine(ex.Message);
            }
        }
    }
}
