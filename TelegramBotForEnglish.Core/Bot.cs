using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Requests;
using TelegramBotForEnglish.Core.Commands;

namespace TelegramBotForEnglish.Core
{
    public class Bot : IBot
    {
        private TelegramBotClient Client;

        public List<Command> Commands { get; private set; }

        public TelegramBotClient GetClient()
        {
            Commands = new List<Command>
            {
                new SayHiCommand(),
                new RepeatCommand()
            };

            return Client;
        }

        public async Task SetWebhook(string url)
        {
            if (Client != null && (await Client.GetWebhookInfoAsync()).Url == url)
                return;

            Client = new TelegramBotClient("983264233:AAEf_mYUP0oVfLdMD3ZIJBdJD0rl-9rMANw");
            await Client.SetWebhookAsync(url);
        }
    }
}
