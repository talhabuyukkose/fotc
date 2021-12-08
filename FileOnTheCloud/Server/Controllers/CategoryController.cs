using Dapper;
using FileOnTheCloud.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly string connectionstring;

        private Helper.FileTp tp;

        public CategoryController(IOptions<ConnectionSetting> connectiongsetting, IOptions<FtpSetting> ftpsetting)
        {
            connectionstring = connectiongsetting.Value.MyDb;

            tp = new Helper.FileTp(ftpsetting);
        }



        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.Category>>> Get()
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.Category>("select * from public.category where isdelete=false order by categoryname asc");

                return Ok(output);
            }
        }

        

       [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Shared.DbModel.Category>> GetById(int id)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.Category>($"select * from public.category where isdelete=false and id={id}");

                return Ok(output.First());
            }
        }

        [HttpGet("GetByDirName/{categoryname}")]
        public async Task<ActionResult<Shared.DbModel.Category>> GetByDirName(string categoryname)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.Category>($"select * from public.category where isdelete=false and categoryname='{categoryname}'");

                return Ok(output.First());
            }
        }

        [HttpGet("GetByLevel/{level}")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.Category>>> GetByLevel(int level)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.Category>($"select * from public.category where isdelete=false and parentlevel={level} order by categoryname asc");

                return Ok(output);
            }
        }

        [HttpGet("GetByParentId/{id}")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.Category>>> GetByParentId(int id)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.Category>($"select * from public.category where isdelete=false and parentid={id} order by categoryname asc");

                return Ok(output);
            }
        }

        [HttpPost("Set")]
        public async Task<ActionResult> Set([FromBody] Shared.DbModel.Category category)
        {
            string procedure = $"call addcategory(@useremail,@parentid,@categoryname, @categoryparentname, @categorypath,@categoryparentpath,@parentlevel);";

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
