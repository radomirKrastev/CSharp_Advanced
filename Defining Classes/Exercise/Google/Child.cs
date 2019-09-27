using System;
namespace Google
{
    public class Child
    {
        private string name;
        private DateTime birthday;

        public string Name => this.name;
        public DateTime Birthday => this.birthday;

        public Child(string name, DateTime birthday)
        {
            this.name = name;
            this.birthday = birthday;
        }
    }
}
