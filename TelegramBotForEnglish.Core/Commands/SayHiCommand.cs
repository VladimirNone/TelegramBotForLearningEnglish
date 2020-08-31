using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotForEnglish.Core.Commands
{
    public class SayHiCommand : Command
    {
        public override string Name => "/hi";

        public override bool IsComplicated => false;

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(message.Chat.Id, "Hi, human");
        }
    }
}
