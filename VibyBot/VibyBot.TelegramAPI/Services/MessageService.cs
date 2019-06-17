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
            var client = Bot.GetClient();
            var adminCommands = Bot.Commands;
            var message = update.Message;
            bool isFinded = false;
            foreach (var command in adminCommands)
            {
                if (command.Contains(message.Text) && command.GetType().BaseType == typeof(AdminCommand))
                {
                    string answer = command.Execute(message.Text, message.Chat.Id).Text;
                    await client.SendTextMessageAsync(message.Chat, answer, replyMarkup: new ReplyKeyboardRemove());
                    isFinded = true;
                    break;
                }
                if (command.Contains(message.Text) && command.GetType().BaseType == typeof(OrderCommand))
                {
                    var answer = command.Execute(message.Text, message.Chat.Id);

                    List<string> labels = answer.Buttoms;

                    if (labels.Count != 0)
                    {
                        List<KeyboardButton[]> buttons = new List<KeyboardButton[]>();

                        foreach (string label in labels)
                        {
                            buttons.Add(new[] { new KeyboardButton(label) });
                        }

                        var inlineKeyboard = new ReplyKeyboardMarkup(buttons.ToArray());
                        inlineKeyboard.ResizeKeyboard = true;

                        await client.SendTextMessageAsync(message.Chat, answer.Text, replyMarkup: inlineKeyboard);
                        isFinded = true;
                        break;
                    }
                    else
                    {
                        await client.SendTextMessageAsync(message.Chat, answer.Text, replyMarkup: new ReplyKeyboardRemove());
                        isFinded = true;
                        break;
                    }
                }
                if (command.GetType() == typeof(FormOrderCommand))
                {
                    var sender = new OrderSender(Bot.OrderStorage, Bot.AdminStorage, Bot.GetClient());
                    await sender.SendOrderToAllAsync(command.Execute(message.Text, message.Chat.Id).CurrentOrder);
                }
            }
            if (!isFinded)
            {
                await client.SendTextMessageAsync(message.Chat, "Некоректний ввід спробуйте ще раз.", replyToMessageId : message.MessageId);
            }
        }
    }
}