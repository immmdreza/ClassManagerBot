using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CManagerBot.Proccesses
{
    interface iUpdates: IDisposable
    {
        string[] Trigger { get; }

        public Task<ProccessResult> Proccess(Update update);
    }
}
