using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace FileOnTheCloud.Server.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class SettingController : ControllerBase
    {
        [HttpGet("GetAvailableFreeDisk")]
        public async Task<ActionResult<double>> GetAvailableFreeDisk()
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var freeBytes = new DriveInfo(path).AvailableFreeSpace;

            var response = Math.Round((freeBytes / 1073741824d)-2,2,MidpointRounding.AwayFromZero); // GB

            return Ok(response);
        }
    }
}
