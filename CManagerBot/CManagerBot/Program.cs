using CManagerBot.Datebases;
using CManagerBot.Proccesses;
using CManagerBot.Proccesses.HandlingRoom;
using CManagerBot.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CManagerBot
{
    class Program
    {
        public static TelegramBotClient Client = new TelegramBotClient("1001291061:AAFc52xCfV_eHVgjNu8mMGxteS6Di589wko");
        public static List<iUpdates> Updates = new List<iUpdates>();
        public static Answer GetAnswer = new Answer();
        public static User ME;

        static async Task Main(string[] args)
        {
            //DbSettiing.AddNewClass(1234567, "me", null, DateTime.UtcNow);
            ME = await Client.GetMeAsync().ConfigureAwait(false);
            var i = (await Methods.AddNewSuperAdmin(106296897).ConfigureAwait(false)).Id;
            Console.WriteLine(i);


            Client.OnUpdate += Client_OnUpdateAsync;

            Client.StartReceiving(new UpdateType[] { UpdateType.CallbackQuery, UpdateType.InlineQuery, UpdateType.Message });

            Updates.Add(new StartMessage());

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Running ... {ME.FirstName} Main");

            var r = (await Methods.GetClass("me").ConfigureAwait(false)).Id;
            Console.WriteLine(r);

            Console.Read();
   
        }

        private static async void Client_OnUpdateAsync(object sender, UpdateEventArgs e)
        {
            if(e.Update is null) { return; }

            using (var uh = new UpdateHandler(e.Update))
            {
                await uh.Handel().ConfigureAwait(false);
            }
        }
    }
}
