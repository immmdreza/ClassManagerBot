using CManagerBot.Datebases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CManagerBot.Proccesses.HandlingRoom
{
    class StartMessage : iUpdates
    {
        public string[] Trigger => new string[] { "/start" };

        public async Task<ProccessResult> Proccess(Update update)
        {

            if (update.Message is null || update.Message.Chat.Type != ChatType.Private)
            {
                return null;
            }

            var st = "";
            if (await Methods.CheckSuperAdmin(update.Message.From.Id).ConfigureAwait(false))
            {
                st = $"سلام عشقم نفسممممممممم بمیرم برات {update.Message.From.TextMention()}";
            }
            else
            {
                st = $"سلام دوست عزیزم {update.Message.From.TextMention()}";
            }

            var pr = new ProccessResult
            {
                ParseMode = ParseMode.Html,
                Chatid = update.Message.Chat.Id,
                DisableNotification = false,
                InlineKeyboardMarkup = null,
                ReplyToMessageid = update.Message.MessageId,
                ResulType = ResulType.SendTextMessage,
                text = st,
                WebPagePreviwe = false
            };

            return pr;

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~StartMessage()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
