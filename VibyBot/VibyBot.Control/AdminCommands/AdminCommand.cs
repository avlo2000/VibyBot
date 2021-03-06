﻿using System;
using System.Collections.Generic;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.AdminCommands
{
    abstract public class AdminCommand : ICommand
    {
        public abstract string Name { get; }

        abstract public Answer Execute(string message, long chatId);

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }

        public Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            throw new NotImplementedException();
        }

        protected IManagementStorage _managementStorage;
        protected IAdminStorage _adminStorage;
        protected IOrderStorage _orderStorage;
        protected ManagerInfo _managerInfo;

        public AdminCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
        {
            _managerInfo = managementStorage.GetConfig();
            _managementStorage = managementStorage;
            _orderStorage = orderStorage;
            _adminStorage = userStorage;
        }
    }
}
