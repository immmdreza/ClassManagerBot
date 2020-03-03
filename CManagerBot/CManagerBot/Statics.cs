using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Encodings.Web;
using Telegram.Bot.Types;

namespace CManagerBot
{
    static class Statics
    {
        public static string TextMention(this User user)
        {
            return $"<a href='tg://user?id={user.Id}'>{HtmlEncoder.Default.Encode(user.FirstName + " " + user.LastName)}</a>";
        }

        public static string Bold(this string st)
        {
            return $"<b>{HtmlEncoder.Default.Encode(st)}</b>";
        }

        public static string Code(this string st)
        {
            return $"<code>{HtmlEncoder.Default.Encode(st)}</code>";
        }

    }
}
