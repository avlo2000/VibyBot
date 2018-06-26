using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using VibyBot.Control.AdminCommands;
using VibyBot.Control.OrderCommands;
using VibyBot.TelegramAPI.Models;

namespace TelegramInteractionPOC.Services
{
    public class MessageService : IMessageService
    {
        public async Task Execute([FromBody]Update update)
        {
            var client = Bot.Get();
            var adminCommands = Bot.Commands;
            var message = update.Message;
            bool isFind = false;
            foreach (var command in adminCommands)
            {
                if (command.Contains(message.Text) && command.GetType().BaseType == typeof(AdminCommand))
                {
                    string answer = command.Execute(message.Text, message.Chat.Id).Text;
                    await client.SendTextMessageAsync(message.Chat, answer, replyMarkup: new ReplyKeyboardRemove());
                    isFind = true;
                    break;
                }
                if (command.Contains(message.Text) && command.GetType().BaseType == typeof(OrderCommand))
                {
                    string answer = command.Execute(message.Text, message.Chat.Id).Text;

                    List<string> labels = command.Execute(message.Text, message.Chat.Id).Buttoms;

                    if (labels.Count != 0)
                    {
                        List<KeyboardButton[]> buttons = new List<KeyboardButton[]>();

                        foreach (string label in labels)
                        {
                            buttons.Add(new[] { new KeyboardButton(label) });
                        }

                        var inlineKeyboard = new ReplyKeyboardMarkup(buttons.ToArray());
                        inlineKeyboard.ResizeKeyboard = true;

                        await client.SendTextMessageAsync(message.Chat, answer, replyMarkup: inlineKeyboard);
                        isFind = true;
                        break;
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat, answer, replyMarkup: new ReplyKeyboardRemove());
                        isFind = true;
                        break;
                    }
                }
            }
            if (!isFind)
            {
                await client.SendTextMessageAsync(message.Chat, "Некоректний ввід спробуйте ще раз.");
            }
        }
    }
}