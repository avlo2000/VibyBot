﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using VibyBot.TelegramAPI.Models;

namespace VibyBot.TelegramAPI.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.GetAsync(/*there  must be given implementation for IManagementStorage*/);
            foreach(var command in commands)
                if (command.Contains(message.Text))
                {
                    await command.Execute(message, client);
                    break;
                }

            return Ok();
        }
    }
}
