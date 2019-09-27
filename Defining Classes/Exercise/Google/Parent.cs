using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Parent
    {
        private string name;
        private DateTime birthday;

        public string Name => this.name;
        public DateTime Birthday => this.birthday;

        public Parent(string name, DateTime birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }
    }
}
