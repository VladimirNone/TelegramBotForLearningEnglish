using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotForEnglish.Core.Commands
{
    class RepeatCommand : Command
    {
        public override string Name => "/repeat";

        public override bool IsComplicated => true;

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            if (IsComplicated && !IsActive)
            {
                IsActive = true;
                return;
            }

            if (IsActive)
                await client.SendTextMessageAsync(message.Chat.Id, message.Text);
        }
    }
}
