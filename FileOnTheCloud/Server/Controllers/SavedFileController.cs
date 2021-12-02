﻿using Dapper;
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
    public class SavedFileController : ControllerBase
    {
        private readonly string connectionstring;

        private Helper.FileTp tp;

        public SavedFileController(IOptions<ConnectionSetting> connectiongsetting, IOptions<FtpSetting> ftpsetting)
        {
            connectionstring = connectiongsetting.Value.MyDb;

            tp = new Helper.FileTp(ftpsetting);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.SavedFile>>> Get()
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>("select * from public.savedfile where isdelete=false order by createdate desc");

                return Ok(output);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Shared.DbModel.SavedFile>> GetById(int id)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>($"select * from public.savedfile where isdelete=false and id={id}");

                return Ok(output.First());
            }
        }

        [HttpGet("GetByUser/{email}")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.SavedFile>>> GetByUser(string email)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>($"select * from public.GetFileForEmail where emailaddress='{email}'");

                return Ok(output);
            }
        }

        [HttpGet("GetByFileName/{filename}")]
        public async Task<ActionResult<Shared.DbModel.SavedFile>> GetByEmail(string filename)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>($"select * from public.savedfile where isdelete=false and filename='{filename}'");

                return Ok(output.First());
            }
        }

        [HttpPost("Set")]
        public async Task<ActionResult> Set([FromBody] Shared.DbModel.SavedFile savefile)
        {
            string procedure = $"call addfile(@userid,@filename,@filesize, @filepath, @fileextension,@department,@grade,@semester,@midtermandfinal);";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var response = await tp.UploadFile(savefile.localpath, savefile.filepath, savefile.filename);
                if (response)
                {
                    var output = await connection.ExecuteAsync(procedure, savefile);

                    return Ok(true);
                }

                return BadRequest(response);
            }
        }


        [HttpPost("Delete")]
        public async Task<ActionResult> Delete([FromBody] Shared.DbModel.SavedFile savefile)
        {
            string procedure = $"call deletefile({savefile.id});";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                await tp.DeleteFile(savefile.filepath, savefile.filename);

                var output = await connection.ExecuteAsync(procedure);

                return Ok(true);
            }
        }
    }
}
