using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using FileOnTheCloud.Shared.Model;

namespace FileOnTheCloud.Client.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorage;
        private readonly AuthenticationState _anonymous;

        public AuthStateProvider(HttpClient httpClient, ISessionStorageService sessionStorage)
        {
            _httpClient = httpClient;
            _sessionStorage = sessionStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            JwtSecurityToken securityToken = new();
            var token = await _sessionStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrWhiteSpace(token))
            {
                NotifyUserLogout();

                return _anonymous;
            }
           
            securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var email = securityToken.Claims.Where(w => w.Type == "email").FirstOrDefault().Value;

            var role = securityToken.Claims.Where(w => w.Type == "role").FirstOrDefault().Value;

            DateTime expirtiontime = DateTime.UnixEpoch.AddSeconds(Convert.ToInt32(securityToken.Payload.Exp?.ToString())).ToLocalTime();


            if (expirtiontime < DateTime.Now)
            {
                await _sessionStorage.RemoveItemAsync("authToken");

                NotifyUserLogout();

                return _anonymous;
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return new AuthenticationState(
                        new ClaimsPrincipal(
                    new ClaimsIdentity(new[]
              {
                  new Claim(ClaimTypes.Email, email.ToString()),
                  new Claim(ClaimTypes.Role, role.ToString())
              }, "apiauth_type")
              )
                );
            //return new AuthenticationState(
            //    new ClaimsPrincipal(
            //  new ClaimsIdentity(Jwtparser.ParseClaimsFormJwt(token), "jwtAuthType")
            //        )
            //    );
        }

        public void NotifyUserAuthentication(string token)
        {

            var readtoken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            var email = readtoken.Claims.Where(w => w.Type == "email").FirstOrDefault().Value;

            var role = readtoken.Claims.Where(w => w.Type == "role").FirstOrDefault().Value;

            DateTime expirtiontime = DateTime.UnixEpoch.AddSeconds(Convert.ToInt32(readtoken.Payload.Exp?.ToString())).ToLocalTime();

            if (expirtiontime < DateTime.Now)
            {
                _sessionStorage.RemoveItemAsync("authToken");

                NotifyUserLogout();
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
             {
                  //new Claim(ClaimTypes.Name, userModel.token.ToString()),
                  new Claim(ClaimTypes.Email, email),
                  new Claim(ClaimTypes.Role, role)
                 }, "apiauth_type");

            ClaimsPrincipal authenticatedUser = new ClaimsPrincipal(claimsIdentity);
            //var authenticatedUser = new ClaimsPrincipal(
            //        new ClaimsIdentity(
            //    Jwtparser.ParseClaimsFormJwt(token), "jwtAuthType"));

            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            NotifyAuthenticationStateChanged(authState);

        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
