using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FileOnTheCloud.Shared.Model;
using FileOnTheCloud.Shared.DbModel;
using Npgsql;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace FileOnTheCloud.Server.Controllers
{

    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private string connectionstring;

        public UserController(IOptions<ConnectionSetting> connectionsetting)
        {
            connectionstring = connectionsetting.Value.MyDb;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.User>>> Get()
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.User>("select * from public.user where isdelete=false");

                return Ok(output);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Shared.DbModel.User>> GetById(int id)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.User>($"select * from public.user where isdelete=false and id={id}");

                output.First().password = "";

                return Ok(output.First());
            }
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<ActionResult<Shared.DbModel.User>> GetByEmail(string email)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.User>($"select * from public.user where isdelete=false and emailaddress='{email}'");

                return Ok(output.First());
            }
        }

        [HttpPost("Set")]
        public async Task<ActionResult> Set([FromBody] Shared.DbModel.User _user)
        {
            _user.password = Helper.Helper.Createhmacsha256(_user.password);

            string procedure = string.Empty;

            if (_user.id == 0)
            {
                procedure = $"call adduser(@name,@surname,@title, @password, @department,@emailaddress);";
            }
            else if (string.IsNullOrEmpty(_user.password))
            {
                procedure = "UPDATE public.user SET name=@name, surname=@surname, title=@title, department=@department, emailaddress=@emailaddress, role=@role WHERE id=@id;";
            }
            else
            {
                procedure = "UPDATE public.user SET name=@name, surname=@surname, title=@title, password=@password, department=@department, emailaddress=@emailaddress, role=@role WHERE id=@id;";
            }
            //string procedure = $"call adduser('{_user.name}','{_user.surname}', '{_user.title}', '{_user.password}', '{_user.department}','{_user.emailaddress}');";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.ExecuteAsync(procedure, _user);

                return Ok(true);
            }
        }

        
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            string sql = $"UPDATE public.user SET isdelete=true WHERE id={id};";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync(sql);

                return Ok(true);
            }
        }
    }
}
