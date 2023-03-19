using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Money
{
    internal class User
    {
        public int id { get; set; }
        private string name, pass;

        public string Name { 
            get { return name; } 
            set { name= value; } 
        }

        public string Pass { 
            get { return pass; } 
            set { pass= value; } 
        }

        public User() { }

        public User(string name, string pass)
        {
            Name = name;
            Pass = pass;
        }
    }
}
