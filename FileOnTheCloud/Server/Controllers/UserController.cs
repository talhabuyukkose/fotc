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

namespace FileOnTheCloud.Server.Controllers
{

    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;

        private string connectionstring;

        public UserController(IConfiguration config)
        {
            this._config = config;

            connectionstring = _config["ConnectionStrings:MyLocalDb"];
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.User>>> Get()
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.User>("select * from public.user");

                return Ok(output);
            }
        }

        [HttpPost("Set")]
        public async Task<ActionResult> Set([FromBody] Shared.DbModel.User _user)
        {
            _user.password = Helper.Helper.Createhmacsha256(_user.password);

            string sql = "INSERT INTO public.user(name, surname, title, password, department, emailaddress, role) VALUES (@name,@surname, @title, @password, @department,@emailaddress,@role);";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.User>(sql,_user);

                return Ok(true);
            }
        }

        [HttpPost("Set/id")]
        public async Task<ActionResult> Set(int id,[FromBody] Shared.DbModel.User _user)
        {
            _user.password = Helper.Helper.Createhmacsha256(_user.password);

            string sql = "UPDATE public.user SET name=@name, surname=@surname, title=@title, password=@password, department=@department, emailaddress=@emailaddress, role=@role WHERE id=@id;";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.User>(sql, _user);

                return Ok(true);
            }
        }


    }
}
