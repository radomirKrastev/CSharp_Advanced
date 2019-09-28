using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members = new List<Person>();
        
        public List<Person> Members
        {
            get => this.members;
            set { this.members = value; }
        }

        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person GetOldestMember()
        {
            var oldestPerson = Members.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }
    }
}
