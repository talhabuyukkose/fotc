using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Instrument
{
    public class Helper : IHelper
    {
        private readonly IModalManager modalManager;

        private readonly HttpClient _httpclient;

        private readonly NavigationManager navigation;

        public Helper(IModalManager _modalManager, HttpClient httpClient, NavigationManager navigationManager)
        {
            modalManager = _modalManager;
            _httpclient = httpClient;
            navigation = navigationManager;
        }


        public async Task<List<T>> GetListTsAsync<T>(string path)
        {
            var classname = typeof(T).GetCustomAttributes(typeof(DisplayNameAttribute), true).First() as DisplayNameAttribute;


            HttpResponseMessage httpResponse = await _httpclient.GetAsync(path);

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                navigation.NavigateTo("/auth/login");

            }
            else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"{classname.DisplayName} listelenemedi !");
            }
            else
            {
                return await httpResponse.Content.ReadFromJsonAsync<List<T>>();
            }

            return new List<T>();
        }

        public async Task<T> GetTsAsync<T>(string path )
        {
            var classname = typeof(T).GetCustomAttributes(typeof(DisplayNameAttribute), true).First() as DisplayNameAttribute;


            HttpResponseMessage httpResponse = await _httpclient.GetAsync(path);

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                navigation.NavigateTo("/auth/login");

            }
            else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"{classname.DisplayName} listelenemedi !");
            }

            return await httpResponse.Content.ReadFromJsonAsync<T>();

        }

        public async Task<System.Net.HttpStatusCode> DeleteTsAsync<T>(string path)
        {
            var classname = typeof(T).GetCustomAttributes(typeof(DisplayNameAttribute), true).First() as DisplayNameAttribute;

            bool confirmed = await modalManager.ConfirmationAsync("Onay bekleniyor", $"{classname.DisplayName} silinecek. Onaylıyor musunuz ?");

            if (!confirmed) return System.Net.HttpStatusCode.BadGateway;

            try
            {
                HttpResponseMessage httpResponse = await _httpclient.DeleteAsync(path);

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await modalManager.ShowMessageAsync("Silme", $"{classname.DisplayName} silindi ");

                    return System.Net.HttpStatusCode.OK;
                }
            }
            catch (HttpRequestException ex)
            {
                await modalManager.ShowMessageAsync("Silme", ex.Message);
            }

            return System.Net.HttpStatusCode.BadGateway;
        }

        public async Task<System.Net.HttpStatusCode> PostTsAsync<T>(string path, T body, string errormessage, string successmessage)
        {

            HttpResponseMessage httpResponse = await _httpclient.PostAsJsonAsync(path, body);

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                navigation.NavigateTo("/auth/login");
            }
            else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", errormessage + "   " + httpResponse.Content + "         " + httpResponse.ReasonPhrase);
            }
            else if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", successmessage);

            }

            return httpResponse.StatusCode;

        }
        public async Task<string> PostReturnValueTsAsync<T>(string path, T body, string errormessage, string successmessage)
        {

            HttpResponseMessage httpResponse = await _httpclient.PostAsJsonAsync(path, body);

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                navigation.NavigateTo("/auth/login");
            }
            else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", errormessage + "   " + httpResponse.Content + "         " + httpResponse.ReasonPhrase);
            }
            else if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //await modalManager.ShowMessageAsync("Bilgi", successmessage);

            }

            return await httpResponse.Content.ReadAsStringAsync();

        }
        public async Task<System.Net.HttpStatusCode> PostFileTsAsync(string path, HttpContent content, string errormessage, string successmessage)
        {

            HttpResponseMessage httpResponse = await _httpclient.PostAsync(path, content);

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await modalManager.ShowMessageAsync("Bilgi", $"Oturum süresi doldu ! Yenilemek için yönlendiriliyorsunuz.");

                navigation.NavigateTo("/auth/login");
            }
            else if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                await modalManager.ShowMessageAsync("Bilgi", errormessage);
            }

            return httpResponse.StatusCode;
        }
    }
}
