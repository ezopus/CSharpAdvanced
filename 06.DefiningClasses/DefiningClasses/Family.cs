using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public List<Person> People
        {
            get => this.people;
            set => this.people = value;
        }
        public void AddMember(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestMember;
        }
        
    }
}