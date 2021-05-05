﻿using discord_bot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension commands { get; private set; }
        
        public async Task RunAsync()
        {
            var json = string.Empty;
            using(var fs = File.OpenRead("config.json"))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                    json = await sr.ReadToEndAsync().ConfigureAwait(false);
            }
            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
                //UseInternalLogHandler = true
                
            };

            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false,
                DmHelp = false,
                IgnoreExtraArguments = true,
            };

            commands = Client.UseCommandsNext(commandsConfig);
            commands.RegisterCommands<PotatoCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
        private Task OnClientReady(object sender,ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }

    }
}
