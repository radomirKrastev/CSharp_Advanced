using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Pokemon
    {
        private string name;
        private string type;

        public string Name => this.name;
        public string Type => this.type;

        public Pokemon(string name, string type)
        {
            this.name = name;
            this.type = type;
        }
    }
}
