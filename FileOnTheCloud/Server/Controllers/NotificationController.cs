using Dapper;
using FileOnTheCloud.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FileOnTheCloud.Server.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        private IConfiguration _config;

        private readonly IMailService _mailService;

        private string connectionstring;

        public NotificationController(IConfiguration config, IMailService mailService)
        {
            _mailService = mailService;

            this._config = config;

            connectionstring = _config["ConnectionStrings:MyDb"];

        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.Notification>>> GetByEmail(string email)
        {
            string sql = $"select * from public.GetNotification_WithEmail where isitseen = {false} and tomail = '{email}'";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.Model.GetNotification_WithEmail>(sql);

                return Ok(output);
            }
        }

        [HttpPost("Seen")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.Notification>>> Seen([FromBody] Shared.Model.GetNotification_WithEmail notification)
        {
            string sql = $"UPDATE public.mailnotification SET isitseen=true	WHERE id={notification.id};";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync(sql);

                return Ok(output);
            }
        }

        [HttpPost("Send")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.Notification>>> Send([FromBody] Shared.Model.MailRequest mail)
        {
            try
            {
                if (string.IsNullOrEmpty(mail.ToEmail))
                {
                    IEnumerable<Shared.DbModel.User> users;

                    using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
                    {
                        users = await connection.QueryAsync<Shared.DbModel.User>($"select * from public.user where isdelete=false and role='admin' ");
                    }

                    mail.ToEmail = string.Join(";", users.Select(s => s.emailaddress));
                }

                await _mailService.SendEmailAsync(mail);

                string procedure = $"call addnotification('{mail.FromEmail}','{mail.ToEmail}','{mail.Body}',{mail.replyid})";

                using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
                {
                    var output = await connection.ExecuteAsync(procedure);

                    return Ok(output);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
