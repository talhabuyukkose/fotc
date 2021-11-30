using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileOnTheCloud.Server.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private IConfiguration _config;

        private string connectionstring;

        private Helper.FileTp tp;

        public CategoryController(IConfiguration config)
        {
            this._config = config;

            connectionstring = _config["ConnectionStrings:MyDb"];

            tp = new Helper.FileTp(config);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.SavedFile>>> Get()
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.User>("select * from public.category where isdelete=false order by createdate desc");

                return Ok(output);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Shared.DbModel.SavedFile>> GetById(int id)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>($"select * from public.category where isdelete=false and id={id}");

                return Ok(output.First());
            }
        }

        [HttpGet("GetByDirName/{categoryname}")]
        public async Task<ActionResult<Shared.DbModel.SavedFile>> GetByEmail(string categoryname)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>($"select * from public.category where isdelete=false and categoryname='{categoryname}'");

                return Ok(output.First());
            }
        }

        [HttpPost("Set")]
        public async Task<ActionResult> Set([FromBody] Shared.DbModel.Category category)
        {
            string procedure = $"call addcategory(@userid,@parentid,@categoryname, @categoryparentname, @categorypath,@categoryparentpath);";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var response = await tp.CreateDir(category.categorypath, category.categoryname);

                if (response)
                {
                    var output = await connection.ExecuteAsync(procedure, category);

                    return Ok(response);
                }

                return BadRequest(response);
            }
        }


        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody] Shared.DbModel.Category category)
        {
            string procedure = $"call deletecategory({category.id});";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                await tp.DeleteDir(category.categorypath);

                var output = await connection.ExecuteAsync(procedure);

                return Ok(true);
            }
        }
    }
}
