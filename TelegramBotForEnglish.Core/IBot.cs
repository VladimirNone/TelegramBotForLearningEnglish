using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotForEnglish.Core.Commands;

namespace TelegramBotForEnglish.Core
{
    public interface IBot
    {
        List<Command> Commands { get; }
        TelegramBotClient GetClient();
        Task SetWebhook(string url);
    }
}
