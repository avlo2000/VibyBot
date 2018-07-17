using System;
using System.Collections.Generic;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control
{
    public interface ICommand
    {
        Answer Execute(string message, long chatId);
        bool Contains(string command);
    }
}
