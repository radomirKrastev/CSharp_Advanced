using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree
{
    public class Person
    {
        private string name;
        private DateTime birthday;
        private List<Person> parents = new List<Person>();
        private List<Person> children = new List<Person>();

        public String Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        public DateTime Birthday
        {
            get => this.birthday;
            set
            {
                this.birthday = value;
            }
        }

        public List<Person> Parents
        {
            get => this.parents;
            set
            {
                this.parents = value;
            }
        }

        public List<Person> Children
        {
            get => this.children;
            set
            {
                this.children = value;
            }
        }

        public Person()
        {

        }

        public Person(DateTime birthday)
        {
            this.Birthday = birthday;
        }

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
    }
}
