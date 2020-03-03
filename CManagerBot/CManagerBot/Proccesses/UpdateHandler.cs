using CManagerBot.UI;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace CManagerBot.Proccesses
{
    class UpdateHandler:IDisposable
    {
        private Update Update;

        public UpdateHandler(Update update)
        {
            if(update is null)
            {
                Dispose();
                return;
            }

            Update = update;
        }

        public async Task Handel()
        {
            string trigger = string.Empty;

            switch (Update.Type)
            {
                case UpdateType.Message:
                    {
                        trigger = Update.Message.Text.Split(' ')[0].ToLower().Replace("@" + Program.ME.Username, "");
                        break;
                    }
                case UpdateType.CallbackQuery:
                    {
                        trigger = Update.CallbackQuery.Data;
                        break;
                    }

                default:return;
            }

            using (var t = Program.Updates.FirstOrDefault(x => x.Trigger.Any(r=>r == trigger)))
            {
                if (t != null)
                {
                    var result = t.Proccess(Update);

                    await Program.GetAnswer.AnswerAsync(result).ConfigureAwait(false);

                }
            }
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
                Update = null;

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UpdateHandler()
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
