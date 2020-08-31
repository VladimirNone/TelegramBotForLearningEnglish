
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TelegramBotForEnglish.Core;

namespace TelegramBotForEnglish
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration conf)
        {
            configuration = conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBot, Bot>();

            services
                .AddControllers()
                .AddNewtonsoftJson();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBot bot)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //ngrok http -host-header=localhost https://localhost:8443
            //https://api.telegram.org/bot983264233:AAEf_mYUP0oVfLdMD3ZIJBdJD0rl-9rMANw/setWebhook?url=https://44819303b3d9.ngrok.io

            app.UseRouting();
            app.UseCors();

            app.Use(async (context, next) =>
            { 
                await bot.SetWebhook(configuration["HostUrl"]);
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
