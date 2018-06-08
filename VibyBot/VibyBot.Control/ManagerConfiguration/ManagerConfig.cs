using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibyBot.Control.ManagerConfiguration
{
    static public class ManagerConfig
    {
        static public string CardNumber { get; set; }

        static public HashSet<string> Prints { set; get; }

        static public string Password { get; set; }
    }
}
