using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace discord_bot.Commands
{
    public class PotatoCommands : BaseCommandModule
    {
        List<string> potatoFacts = new List<string>();

        [Command("potatofact")]
        [Description("Sends random potato fact")]
        public async Task potatoFact(CommandContext ctx)
        {
            potatoFacts.AddRange(new string[]{
"Each spud has a use",
"There are many, MANY potatoes you have not heard of",
"When you buy them, potatoes are still alive",
"A sweet potato is not actually a potato",
"Potatoes were first grown in South America",
"Potatoes were the first vegetable grown in space",
"Potatoes can turn green",
"Potatoes last a long time if you treat them right",
"Potato chips, as we know them, were invented by mistake",
"Potatoes are not just for eating"
});
            Random rand = new Random();

            await ctx.Channel.SendMessageAsync("```"+ potatoFacts[rand.Next(0,potatoFacts.Count)] + "```").ConfigureAwait(false);
        }
        [Command("hentai")]
        [Description("sends hentai")]
        public async Task Hentai(CommandContext ctx)
        {
            Random rand = new Random();
            int codefirst = rand.Next(1, 4);
            int codeSec;
            if (codefirst == 3)
            {
                codeSec = rand.Next(0, 5);
            }
            else
            {
                codeSec = rand.Next(0, 10);
            }
            string code = "https://nhentai.to/g/" + codefirst.ToString() + codeSec.ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString();
            await ctx.Channel.SendMessageAsync(code).ConfigureAwait(false);
        }
    }
}
