namespace Delegates.Logic.Common.Entities
{
    public class Person
    {
        public string Name { get; init; }

        public Gender Gender { get; init; }
        
        public int Age { get; init; }
        public Person(string name, Gender gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
        }
    }
}