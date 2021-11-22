using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileOnTheCloud.Shared.Model;
using FileOnTheCloud.Shared.DbModel;
using Dapper;
using Npgsql;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FileOnTheCloud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login data)
        {
            IActionResult response = Unauthorized();

            data.password = Helper.Helper.Createhmacsha256(data.password);

            var user = AuthenticateUser(data);

            if (user != null)
            {
                string tokenString = GenerateJSONWebToken(user);

                response = Ok(new { token = tokenString });

                userLog(data.username, tokenString);
            }

            return response;
        }

        private void userLog(string email, string token)
        {
            using (var connection = new Npgsql.NpgsqlConnection(_config["ConnectionStrings:MyLocalDb"]))
            {
                var output = connection.Execute($"INSERT INTO public.user_log(createdate, token, description) VALUES ( timezone('turkey', now()),'{token}','');");
            }
        }
        private Shared.DbModel.User AuthenticateUser(Login login)
        {
            using (var connection = new Npgsql.NpgsqlConnection(_config["ConnectionStrings:MyLocalDb"]))
            {
                var output = connection.Query<Shared.DbModel.User>("select * from public.user where emailaddress=@username and password=@password", login).ToList();

                if (output.Count != 0)
                    return output.First();

                return null;
            }
        }

        private string GenerateJSONWebToken(Shared.DbModel.User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,// _config["Jwt:Issuer"],
                audience: null,// _config["Jwt:Issuer"],
                claims: new[]
                {
                    new Claim("email",userInfo.emailaddress),
                    new Claim("role",userInfo.role)
                },
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:expires"])),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
