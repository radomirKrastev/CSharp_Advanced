using System.Collections.Generic;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int,Person> data;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public int Count => this.data.Count;

        public void Add(Person person)
        {
            this.data.Add(data.Count, person);
        }

        public Person Get(int id)
        {
            if (this.data.ContainsKey(id))
            {
                return this.data[id];
            }

            return null;
        }

        public bool Update(int id, Person person)
        {
            if (this.data.ContainsKey(id))
            {
                this.data[id] = person;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.data.ContainsKey(id))
            {
                this.data.Remove(id);
                return true;
            }

            return false;
        }
    }
}
