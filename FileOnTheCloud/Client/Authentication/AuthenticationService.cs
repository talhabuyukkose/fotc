using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileOnTheCloud.Client.Authentication
{
    public class AuthenticationService : IAuthenticationService 
    {
        private readonly HttpClient client;
        private readonly AuthenticationStateProvider authStateProvider;
        //private readonly ILocalStorageService localStorage;
        private readonly ISessionStorageService sessionStorage;

        public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ISessionStorageService sessionStorage)
        {
            this.client = client;
            this.authStateProvider = authStateProvider;
            //this.localStorage = localStorage;
            this.sessionStorage = sessionStorage;
        }

        public async Task<HttpResponseMessage> Login(FileOnTheCloud.Shared.Model.Login loginmodel)
        {
            await this.sessionStorage.RemoveItemAsync("authToken");

            HttpResponseMessage httpResponse = await this.client.PostAsJsonAsync("api/Auth/login", loginmodel);

            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return httpResponse;
            }

            var authenticated = await httpResponse.Content.ReadFromJsonAsync<FileOnTheCloud.Shared.Model.Authenticated>();
            var token = authenticated.token;

            await this.sessionStorage.SetItemAsync("authToken", token);

            ((AuthStateProvider)this.authStateProvider).NotifyUserAuthentication(token);

            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return httpResponse;
        }

        public async Task Logout()
        {
            await this.sessionStorage.RemoveItemAsync("authToken");

            ((AuthStateProvider)this.authStateProvider).NotifyUserLogout();
        }
    }
}
