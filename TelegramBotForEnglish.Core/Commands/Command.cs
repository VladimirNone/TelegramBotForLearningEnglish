using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotForEnglish.Core.Commands
{
    public abstract class Command
    {
        public static string LastCommandName { get; set; }
        protected static bool IsActive { get; set; }

        public abstract string Name { get; }
        public abstract bool IsComplicated { get; }

        public static void ChangeCommand(string name)
        {
            LastCommandName = name;
            IsActive = false;
        }

        public abstract Task Execute(Message message, TelegramBotClient client);
    }
}
