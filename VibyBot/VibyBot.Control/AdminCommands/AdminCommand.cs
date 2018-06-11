﻿using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Conrol.AdminCommands
{
    abstract public class AdminCommand
    {
        public abstract string Name { get; }

        abstract public Task Execute(Message message, TelegramBotClient client);

        public string Answer { get; protected set; }

        public IUserStorage UserInfo;

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }

        protected ManagerInfo _managerInfo;
        protected IManagementStorage _managementStorage;

        public AdminCommand(IManagementStorage managementStorage)
        {
            _managementStorage = managementStorage;
           _managerInfo = _managementStorage.GetConfig();
        }
    }
}
