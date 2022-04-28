using System.Collections.Generic;
using System.Linq;
using Delegates.Logic.Common.Entities;

namespace Delegates.Logic.Example2
{
    public static class Example2
    {
        public static void Execute()
        {
            IEnumerable<Person> persons1 = new List<Person>()
            {
                new Person("Jack", Gender.Man,15),
                new Person("John", Gender.Man,25),
                new Person("Fredericka", Gender.Woman,21),
            };

            bool result1 = persons1.MyAll(person => person.Gender == Gender.Woman);
            
            bool result2 = persons1.MyAny(person => person.Gender == Gender.Man);

            IEnumerable<Person> result3 = persons1
                .MySelect(person=>person)
                .MyWhere(person => person.Age > 20); 

            var result4 = persons1
                .MyWhere(person => person.Age > 20)
                .MySelect(person => new {IsAdult = true, Name = person.Name})
                .ToList();
        }
    }
}