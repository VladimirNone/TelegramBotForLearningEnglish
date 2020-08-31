using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBotForEnglish.Core;
using TelegramBotForEnglish.Core.Commands;

namespace TelegramBotForEnglish.Controllers
{
    [Route("")]
    public class MessageController : Controller
    {
        private readonly IBot bot;
        public MessageController(IBot _bot)
        {
            bot = _bot;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody]Update update)
        {
            var client = bot.GetClient();

            if (update.Message.Text[0] != '/')
            {
                if (string.IsNullOrEmpty(Command.LastCommandName))
                    return Ok();
                await bot.Commands.Single(h => h.Name == Command.LastCommandName)?.Execute(update.Message, client);
            }

            foreach (var item in bot.Commands)
            {
                if (item.Name.Equals(update.Message.Text)) 
                {
                    if(item.IsComplicated)
                        Command.ChangeCommand(update.Message.Text);
                    await item.Execute(update.Message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}
