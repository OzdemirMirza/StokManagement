﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class UserProb
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public UserProb(string name, string password, string userName)
        {
            Name = name;
            Password = password;
            UserName = userName;
        }
    }
}
