using System.Collections.Generic;

namespace VibyBot.Persistence.ManagerConfiguration
{
    static public class ManagerConfig
    {
        static public string CardNumber { get; set; } = "5613 3421 3231 4421";

        static public HashSet<string> Prints { set; get; } = new HashSet<string>();

        static public string Password { get; set; } = "123";
    }
}
