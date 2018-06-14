using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibyBot.Control
{
    public interface ICommand
    {
        string Execute(string message, long chatId);
        bool Contains(string command);
    }
}
