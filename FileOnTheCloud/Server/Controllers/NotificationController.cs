﻿using Dapper;
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
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
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

            connectionstring = _config["ConnectionStrings:MyLocalDb"];

        }

        [HttpPost("Get")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.Notification>>> Get([FromBody] string email)
        {
            string sql = $"select * from public.mailnotification where isitseen={false} and touserid = (select id from public.user where emailaddress='{email}')";

            using (var connection = new Npgsql.NpgsqlConnection(connectionstring))
            {
                var output = await connection.QueryAsync<Shared.DbModel.Notification>(sql);

                return Ok(output);
            }
        }

        [HttpPost("Seen")]
        public async Task<ActionResult<IEnumerable<Shared.DbModel.Notification>>> Seen([FromBody] Shared.DbModel.Notification notification)
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

                await _mailService.SendEmailAsync(mail);

                string procedure = $"call AddNotification('{mail.FromEmail}','{mail.ToEmail}','{mail.Body}')";

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
