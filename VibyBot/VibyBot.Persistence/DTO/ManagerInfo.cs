﻿using System;
using System.Collections.Generic;

namespace VibyBot.Persistence.DTO
{
    public class ManagerInfo
    {
        public ManagerInfo()
        {
            Prints = new HashSet<string>();
        }

        public HashSet<string> Prints { set; get; }

        public string Password { get; set; }

    }
}