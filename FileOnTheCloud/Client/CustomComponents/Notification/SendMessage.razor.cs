using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.CustomComponents.Notification
{
    public partial class SendMessage
    {

        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string fromemail { get; set; }

        [Parameter]
        public string toemail { get; set; }

        [Parameter]
        public int replyid { get; set; }

        FileOnTheCloud.Shared.Model.MailRequest mail = new FileOnTheCloud.Shared.Model.MailRequest();

        public async override Task SetParametersAsync(ParameterView parameters)
        {
            toemail = parameters.GetValueOrDefault<string>("toemail") ?? "";
            fromemail = parameters.GetValueOrDefault<string>("fromemail") ?? "";
            replyid = parameters.GetValueOrDefault<int>("replyid");

            await base.SetParametersAsync(parameters);
        }
        private async Task SendMail()
        {

            mail.ToEmail = toemail;
            mail.FromEmail = fromemail;
            mail.Subject = "Gönderen :" + fromemail;
            mail.replyid = replyid;

            var httpResponse = await _httpclient.PostAsJsonAsync("api/notification/send", mail);

            if (httpResponse.IsSuccessStatusCode == false)
            {
                Console.WriteLine($"Status : {httpResponse.StatusCode} Message : {httpResponse.Content}");
            }

            var httpContent = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await BlazoredModal.CloseAsync(ModalResult.Ok(true));
            }
            else
            {
                await BlazoredModal.CloseAsync(ModalResult.Ok(false));
            }
        }
    }
}
