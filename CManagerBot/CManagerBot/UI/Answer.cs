using CManagerBot.Proccesses;
using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CManagerBot.UI
{
    class Answer
    {
        TelegramBotClient Client = Program.Client;

        public async Task<object> AnswerAsync(ProccessResult r)
        {
            if(r is null) { throw new Exception("Result is null"); }

            switch (r.ResulType)
            {
                case ResulType.SendTextMessage:
                    {
                        return await Client.SendTextMessageAsync(r.Chatid, r.text, r.ParseMode, r.WebPagePreviwe, r.DisableNotification
                            , r.ReplyToMessageid, r.InlineKeyboardMarkup).ConfigureAwait(false);
                    }
                case ResulType.EditMessage:
                    {
                        return await Client.EditMessageTextAsync(r.Chatid,r.Messageid, r.text, r.ParseMode, r.WebPagePreviwe
                            , r.InlineKeyboardMarkup).ConfigureAwait(false);
                    }

                default:throw new Exception("Unkown result type");
            }
        }
    }
}
