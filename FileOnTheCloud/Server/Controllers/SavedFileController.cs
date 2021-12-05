using Dapper;
using FileOnTheCloud.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
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

                foreach (var item in output)
                {
                    item.createdate = item.createdate.ToUniversalTime();
                }

                return Ok(output);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Shared.DbModel.SavedFile>> GetById(int id)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>($"select * from public.savedfile where isdelete=false and id={id}");
                foreach (var item in output)
                {
                    item.createdate = item.createdate.ToUniversalTime();
                }
                return Ok(output.First());
            }
        }

        [HttpGet("GetByUser/{email}")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.SavedFile>>> GetByUser(string email)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>($"select * from public.GetFileForEmail where emailaddress='{email}'");
                foreach (var item in output)
                {
                    item.createdate = item.createdate.ToUniversalTime();
                }
                return Ok(output);
            }
        }

        [HttpGet("GetByFileName/{filename}")]
        public async Task<ActionResult<Shared.DbModel.SavedFile>> GetByEmail(string filename)
        {
            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.SavedFile>($"select * from public.savedfile where isdelete=false and filename='{filename}'");
                foreach (var item in output)
                {
                    item.createdate = item.createdate.ToUniversalTime();
                }
                return Ok(output.First());
            }
        }

        [RequestSizeLimit(104857600)]
        [RequestFormLimits(BufferBody = true, MultipartBodyLengthLimit = 104857600)]
        [HttpPost("SetFile")]
        public async Task<ActionResult> SetFile([FromForm] Shared.DbModel.SavedFile savefile)
        {
            MemoryStream ms = new MemoryStream();

            await savefile.formFile.OpenReadStream().CopyToAsync(ms);

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var response = await tp.UploadFileData(ms.ToArray(), savefile.filepath, savefile.filename);

                if (response)
                {
                    string procedure = $"call addfile(@useremail,@filename,@filesize, @filepath, @fileextension,@department,@grade,@semester,@midtermandfinal,@contenttype);";

                    var output = await connection.ExecuteAsync(procedure, savefile);

                    return Ok(true);
                }

                return BadRequest(response);
            }

        }


        [HttpPost("SetFilePath")]
        public async Task<ActionResult> SetFilePath([FromBody] Shared.DbModel.SavedFile savefile)
        {

            string procedure = $"call addfile(@useremail,@filename,@filesize, @filepath, @fileextension,@department,@grade,@semester,@midtermandfinal,@contenttype);";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var response = await tp.UploadFilePath(savefile.localpath, savefile.filepath, savefile.filename);

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
            string procedure = $"UPDATE public.savedfile SET isdelete=true, deletedate=timezone('turkey',now()) WHERE public.savedfile.id={ savefile.id};";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                await tp.DeleteFile(savefile.filepath, savefile.filename);

                var output = await connection.ExecuteAsync(procedure);

                return Ok(true);
            }
        }

        [HttpPost("GetFile")]
        public async Task<ActionResult> GetFile([FromBody] Shared.DbModel.SavedFile savefile)
        {
            var response = await tp.GetFile(savefile.filepath, savefile.filename);

            if (!string.IsNullOrEmpty(response))
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}



//[HttpPost("SetFileForm")]
//public async Task<ActionResult> SetFileForm(IFormFile savefile)
//{

//    #region Bu api ye nasıl istek atılır

//    //MemoryStream ms = new MemoryStream();
//    //await item.OpenReadStream(104857600).CopyToAsync(ms);

//    //var multipartContent = new MultipartFormDataContent();

//    //var byteArrayContent = new ByteArrayContent(ms.ToArray());

//    //multipartContent.Add(byteArrayContent, "savefile", item.Name);


//    //var response = await _httpclient.PostAsync("api/savedfile/SetFileForm", multipartContent);

//    #endregion


//    var temp = savefile.FileName;



//    return Ok(temp);

//}


//[HttpPost("SetFileData")]
//public async Task<ActionResult> SetFileData([FromBody] Shared.DbModel.SavedFile savefile)
//{

//    #region Bu apiye nasıl istek atılır.


//    //MemoryStream ms = new MemoryStream();
//    //await item.OpenReadStream(104857600).CopyToAsync(ms);
//    //savingfile.filedata = ms.ToArray();

//    //var response = await helper.PostTsAsync<FileOnTheCloud.Shared.DbModel.SavedFile>("api/savedfile/SetFileData", savingfile, "Dosya yüklemede bir sorun oluştu", "Dosya yükleme başarı ile tamamlandı");

//    #endregion

//    string procedure = $"call addfile(@useremail,@filename,@filesize, @filepath, @fileextension,@department,@grade,@semester,@midtermandfinal);";

//    using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
//    {
//        var response = await tp.UploadFileData(savefile.filedata, savefile.filepath, savefile.filename);

//        if (response)
//        {
//            var output = await connection.ExecuteAsync(procedure, savefile);

//            return Ok(true);
//        }

//        return BadRequest(response);
//    }
//}