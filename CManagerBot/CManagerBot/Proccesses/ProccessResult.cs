using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CManagerBot.Proccesses
{
    class ProccessResult
    {
        public ResulType ResulType { get; set; }
        public string text { get; set; }
        public long Chatid { get; set; }
        public int Messageid { get; set; }
        public ParseMode ParseMode { get; set; }
        public InlineKeyboardMarkup InlineKeyboardMarkup { get; set; }
        public int ReplyToMessageid { get; set; }
        public bool DisableNotification { get; set; }
        public bool WebPagePreviwe { get; set; }

    }

    enum ResulType
    {
        SendTextMessage,
        EditMessage
    }
}
