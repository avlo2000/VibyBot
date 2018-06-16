using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Conrol;

namespace VibyBot.Control.OrderCommands
{
    public class StartCommand : OrderCommand
    {
        public override string Name => @"/start";

        public async override Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            Answer = "Чи бажаєте ви щось замовити?";

            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup(
            new Telegram.Bot.Types.ReplyMarkups.KeyboardButton[][]
                {
                // First row
                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton[] {
                        // First column
                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("ТАК"),
                        new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("НІ")
                    },
            });

            await client.SendTextMessageAsync(chatId, Answer, Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
        }

        public override bool Contains(string command)
        {
            return command.Contains(Name);
        }
    }
}
