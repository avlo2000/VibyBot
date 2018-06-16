using System;
using System.Collections.Generic;

namespace VibyBot.Persistence.DTO
{
    public class ManagerInfo
    {
        public HashSet<string> Prints { set; get; }

        public string Password { get; set; }

    }
}