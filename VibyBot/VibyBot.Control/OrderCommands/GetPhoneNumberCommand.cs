using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.OrderCommands
{
    public class GetPhoneNumberCommand : OrderCommand
    {
        public override string Name => @"/getphonenumber";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            throw new NotImplementedException();
        }
        public override bool Contains(string command)
        {
            foreach (string print in _managementStorage.GetConfig().Prints)
            {
                if (command.Contains(print))
                {
                    return true;
                }
            }
            return false;
        }

        public GetPhoneNumberCommand(IManagementStorage managementStorage, IOrderStorage orderStorage)
           : base(managementStorage, orderStorage)
        {
        }
    }
}
